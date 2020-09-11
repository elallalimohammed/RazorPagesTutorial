using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesEventMaker_Chapter13.Interfaces;

namespace RazorPagesEventMaker_Chapter13
{
    public class CreateEventModel : PageModel
    {
        IEventRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public SelectList CountryCodes { get; set; }
        public CreateEventModel(IEventRepository repository, ICountryRepository crepo)
        {
            repo = repository;
            
            Dictionary<string,Country> countries = crepo.GetAllCountries();
            
            CountryCodes = new SelectList(countries.Values, "Code", "Name");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }
    }
}