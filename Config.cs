using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using System.Xml.Serialization;

namespace Countdown
{
    public class Config : IRocketPluginConfiguration
    {
        public Event _events;
        public bool DDMMYYYY;
    
        public void LoadDefaults()
        {
            DDMMYYYY = true;
            
            _events = new Event()
            {
                EventList = new List<Time> { new Time("Wipe", 2017, 1, 10, 3, 30, "Clearing the map"), new Time("Christmas", 2017, 12, 25, 0, 30, "Festive Event")}
            };
        }

        public class Event
        {
            public Event() { }

            [XmlArrayItem(ElementName = "Event")]
            public List<Time> EventList;

        }

        public class Time
        {
            public Time() { }
            public Time(string _name, int _year, int _month, int _day, int _hour, int _minutes, string _info)
            {
                Year = _year;
                Name = _name;
                Month = _month;
                Day = _day;
                Hour = _hour;
                Minutes = _minutes;
                info = _info;
            }

            public string Name;
            public int Year;
            public int Month;
            public int Day;
            public int Hour;
            public int Minutes;
            public string info;
        }
    }
}
