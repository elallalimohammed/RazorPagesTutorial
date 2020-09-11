using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker_Chapter13.Interfaces;

namespace RazorPagesEventMaker_Chapter13
{
    public class DeleteCountryModel : PageModel
    {
        ICountryRepository repo;

        [BindProperty]
        public Country Country { get; set; }

        public DeleteCountryModel(ICountryRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(string code)
        {
            Country = repo.GetCountry(code);
            
            return Page();
        }

        public IActionResult OnPost(string code)
        {
            if (Country != null)
            {
                repo.DeleteCountry(code);
            }

            return RedirectToPage("IndexCountry");
        }
    }
}