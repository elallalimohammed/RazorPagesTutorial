using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter13.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        Country GetCountry(string code);
        void DeleteCountry(string code);
        void AddCountry(Country country);
    }
}
