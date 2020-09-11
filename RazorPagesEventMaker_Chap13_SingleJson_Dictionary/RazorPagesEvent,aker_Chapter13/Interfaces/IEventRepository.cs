
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter13
{
    public interface IEventRepository
    {
        Dictionary<int, Event> GetAllEvents();
        Event GetEvent(int id);
        void AddEvent(Event ev);
     
        void UpdateEvent(Event ev);
     
        Dictionary<int, Event> SearchEventsByCode(string code);

    }
}
