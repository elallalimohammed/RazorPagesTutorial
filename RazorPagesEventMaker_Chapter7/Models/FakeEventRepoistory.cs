using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter7
{
    public class FakeEventRepository
    {
        private List<Event> events { get; }

        public FakeEventRepository()
        {
            events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Roskilde Festival",
                Description = " A lot of music",
                City = "Roskilde",
                DateTime = new DateTime(2020, 6, 9, 10, 0, 0)
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "CPH Marathon",
                Description = " Many Marathon runners",
                City = "Copenhagen",
                DateTime = new DateTime(2020, 3, 6, 9, 30, 0)
            });
            events.Add(new Event()
            {
                Id = 3,
                Name = "CPH Distorsion",
                Description = " A lot of beers",
                City = "Copenhagen",
                DateTime = new DateTime(2019, 6, 4, 14, 0, 0)
            });
            events.Add(new Event()
            {
                Id = 4,
                Name = "Demo Day",
                Description = "Project Presentation",
                City = "Roskilde",
                DateTime = new DateTime(2020, 6, 9, 9, 0, 0)
            });
            events.Add(new Event()
            {
                Id = 5,
                Name = "VM Badminton",
                Description = "Badminton",
                City = "Århus",
                DateTime = new DateTime(2020, 10, 3, 16, 0, 0)
            });
        }

        public List<Event> GetAllEvents()
        {
            return events.ToList();
        }
        public void AddEvent(Event ev)
        {
            List<int> eventIds = new List<int>();

            foreach (var evt in events)
            {
                eventIds.Add(evt.Id);
            }
            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }
            events.Add(ev);
        }
    }
}
