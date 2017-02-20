using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Core;
using Rocket.Core.Commands;
using Rocket.Unturned.Chat;
using Countdown;

namespace Events
{
    public class cEvents : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string>();
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Both;
            }
        }

        public string Help
        {
            get
            {
                return "";
            }
        }

        public string Name
        {
            get
            {
                return "events";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "event" };
            }
        }

        public string Syntax
        {
            get
            {
                return "/events";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            List<string> s = new List<string>();
            foreach (Config.Time ct in Main.Instance.Configuration.Instance._events.EventList)
            {
                DateTime thi = new DateTime(ct.Year, ct.Month, ct.Day, ct.Hour, ct.Minutes, 0, DateTimeKind.Local);
                if (!(thi.Ticks < DateTime.Now.Ticks))
                { s.Add(ct.Name); }
            }

            UnturnedChat.Say(caller, "Current Events: " + String.Join(", ", s.ToArray()));
        }
    }
}
