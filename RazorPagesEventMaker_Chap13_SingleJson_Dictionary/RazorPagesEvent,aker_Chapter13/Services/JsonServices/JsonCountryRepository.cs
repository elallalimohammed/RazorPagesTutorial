
using RazorPagesEventMaker_Chapter13;
using RazorPagesEventMaker_Chapter13.Interfaces;
using RazorpagesEventMaker_Chapter13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMaker_Chapter13.Helpers;

namespace RazorPagesEvent_aker_Chapter13.Services.JsonServices
{
    public class JsonCountryRepository : ICountryRepository
    {
        string JsonFileName = @"C:\Users\EASJ\Desktop\Dernier\chap13_dictionary\RazorPagesEvent,aker_Chapter13\Data\JsonCountries.json";
        public Dictionary<string,Country> GetAllCountries()
        {
            Dictionary<string,Country> returnList = JsonFileCountryReader.ReadJson(JsonFileName);
            return returnList;
        }
        public void AddCountry(Country country)
        {
            Dictionary<string, Country> countries = GetAllCountries();
            countries.Add(country.Code,country);
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }
        public Country GetCountry(string code)
        {
            foreach (var c in GetAllCountries())
            {
                if (c.Key == code)
                    return c.Value;
            }
            return new Country();
        }
        public void DeleteCountry(string code)
        {
            Dictionary<string, Country> countries = GetAllCountries();

            foreach (var c in countries)
            {
                if (c.Key == code)
                {
                    countries.Remove(c.Key);
                    break;
                }
            }
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }       
    }
}
