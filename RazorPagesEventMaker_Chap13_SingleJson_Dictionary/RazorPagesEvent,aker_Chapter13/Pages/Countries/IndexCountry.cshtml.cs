using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker_Chapter13.Interfaces;

namespace RazorPagesEventMaker_Chapter13
{
    public class IndexCountryModel : PageModel
    {
        ICountryRepository repo;
        public IndexCountryModel(ICountryRepository repository)
        {
            repo = repository;
        }
        public Dictionary<string,Country> Countries { get; private set; }
        public IActionResult OnGet()
        {
            Countries = repo.GetAllCountries();
            
            return Page();
        }
    }
}