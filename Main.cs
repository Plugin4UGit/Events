using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using System.Threading;
using System.Xml.Linq;
using System.Globalization;
using Rocket.API.Collections;
using SDG.Unturned;
using Rocket.Core.Commands;

namespace Countdown
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        public List<DateTime> EventTime;

        protected override void Load()
        {
            Instance = this;
            base.Load();
            Rocket.Core.Logging.Logger.Log("Event Counter Loaded");

        }


        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList
                {
                    { "noevents", "There are no current events!"},
                    { "time", "{0} is set for the {1} at {2}:{3}{4}" },
                    { "daysleft", "{0} is happening in {1} days and {2} hour(s)" },
                    { "dayleft", "{0} is happening in {1} day and {2} hour(s)" },
               

            };
            }
        }
    }
}
