using RazorpagesEventMaker_Chapter10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter10.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEvent(int id);
        void AddEvent(Event ev);
        void DeleteEvent(Event ev);
        void UpdateEvent(Event ev);
        List<Event> FilterEvents(string city);

    }
}
