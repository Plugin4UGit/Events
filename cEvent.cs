using Rocket.API;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Countdown;
using System.Globalization;

namespace Countdown
{
    public class cEvent : IRocketCommand
    {
        public List<string> Aliases { get { return new List<string>(); } }

        public AllowedCaller AllowedCaller { get { return AllowedCaller.Both; } }


        public string Help { get { return "Countdown to an event"; } }
        public string Name { get { return "event"; } }


        public List<string> Permissions { get { return new List<string> { "event" }; } }


        public string Syntax { get { return "/event <event name> for info"; } }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            bool found = false;
 
            if (command.Length == 1)
            {

                foreach (Config.Time ct in Main.Instance.Configuration.Instance._events.EventList)
                {

                    if (command[0].ToLower() == ct.Name.ToLower())
                    {

                        DateTime thi = new DateTime(ct.Year, ct.Month, ct.Day, ct.Hour, ct.Minutes, 0, DateTimeKind.Local);
                        if (DateTime.Now.Ticks < thi.Ticks) 
                        {
                            found = true;
                            TimeSpan s = new TimeSpan(thi.Ticks - DateTime.Now.Ticks);
                            int hours = ct.Hour;
                            string ampm = "am";
                            if (hours == 0)
                                hours = 12;
                            else if (hours == 12)
                                ampm = "pm";
                            else if (hours > 12)
                            {
                                hours -= 12;
                                ampm = "pm";
                            }

                            string formattedTime = hours.ToString();
                            string dte = "";
                            if (Main.Instance.Configuration.Instance.DDMMYYYY)
                                dte = thi.Date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
                            else
                                dte = thi.Date.ToString();
                            UnturnedChat.Say(dte);

                            UnturnedChat.Say(caller, Main.Instance.Translate("time", ct.Name, dte, formattedTime, s.Minutes, ampm));
                            if (s.Days == 1)
                                UnturnedChat.Say(caller, Main.Instance.Translate("dayleft", ct.Name, s.Days, s.Hours));
                            else
                                UnturnedChat.Say(caller, Main.Instance.Translate("daysleft", ct.Name, s.Days, s.Hours));

                            UnturnedChat.Say(caller, ct.info);

                        }          
                    }
                }
                if (!found)
                    UnturnedChat.Say(caller, "Event not found, type /events for a list of events");
            }
            else
            {
         
                UnturnedChat.Say(caller, "Type /events for a list of events");
            }       
        }
    }
}
