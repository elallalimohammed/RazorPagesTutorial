
using RazorPagesEventMaker_Chapter13;
using RazorPagesEventMaker_Chapter13.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEvent_aker_Chapter13.Services.JsonServices
{
    public class JsonCountryRepository : ICountryRepository
    {
        string JsonFileName = @"C:\Users\EASJ\Source\Repos\Razorpages\RazorPagesEvent,aker_Chapter13\Data\JsonCountries.json";

        public List<Country> GetAllCountries()
        {
            List<Country> returnList = JsonFileCountryReader.ReadJson(JsonFileName);
            return returnList;
        }
        public void AddCountry(Country country)
        {
            List<Country> countries = GetAllCountries().ToList();
            if (country != null)
            {
                countries.Add(country);
                JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
            }
        }
        public Country GetCountry(string code)
        {
            foreach (var c in GetAllCountries())
            {
                if (c.Code == code)
                    return c;
            }
            return new Country();
        }
        public void DeleteCountry(string code)
        {
            List<Country> countries = GetAllCountries().ToList();

            foreach (var c in countries)
            {
                if (c.Code == code)
                {
                    countries.Remove(c);
                    break;
                }
            }
            JsonFileCountryWritter.WriteToJson(countries, JsonFileName);
        }
    }
}
