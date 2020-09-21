
using RazorPagesEventMaker_Chapter13;
using RazorPagesEventMaker_Chapter13.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonFileCountryReader = RazorPagesEventMaker_Chapter13.Helpers.JsonFileCountryReader;

namespace RazorPagesEvent_aker_Chapter13.Services.JsonServices
{
    public class JsonEventRepository : IEventRepository
    {
        string JsonFileName = @"C:\Users\EASJ\Desktop\Dernier\chap13_dictionary\RazorPagesEvent,aker_Chapter13\Data\JsonCountries.json";
        public Dictionary<int,Event> GetAllEvents()
        {
            Dictionary<int, Event> listEvents = new Dictionary<int, Event>();
            Dictionary<string, Country> countries = GetAllCountries();
            foreach (var c in countries)
            {
                 foreach (var ev in c.Value.EventList)
                    {
                       listEvents.Add(ev.Key, ev.Value);
                    }
            }
            return listEvents;
        }

        public void AddEvent(Event evt)
        {
            Dictionary<string, Country> countries = GetAllCountries();
            evt.Id= GetCount(countries)+1;         
            countries[evt.CountryCode].EventList.Add(evt.Id, evt);
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }
        private int GetCount(Dictionary<string, Country> countries)
        {
            int total=0;
            foreach(var c in countries)
            {
                total += c.Value.EventList.Count;
            }
            return total;
        }
        public Event GetEvent(int id)
        {
            foreach(var c in GetAllCountries())
            {
                foreach (var v in c.Value.EventList)
                {
                    if (v.Key == id)
                    return v.Value;
                }
            }            
            return new Event();
        }
        private Dictionary<string, Country> GetAllCountries()
        {
            Dictionary<string, Country> returnList = JsonFileCountryReader.ReadJson(JsonFileName);
            return returnList;
        }

        public void UpdateEvent(Event @evt)
        {
            Dictionary<string, Country> countries = GetAllCountries();
            Event ev = countries[@evt.CountryCode].EventList[@evt.Id];
            ev.Name = evt.Name;
            ev.City = evt.City;
            ev.Description = evt.Description;
            ev.DateTime = evt.DateTime;
            ev.CountryCode = evt.CountryCode;
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }
        public Dictionary<int, Event> SearchEventsByCode(string code)
        {
           Dictionary<string, Country> countries = GetAllCountries();
           return countries[code].EventList;               
        }
        
    }
}
