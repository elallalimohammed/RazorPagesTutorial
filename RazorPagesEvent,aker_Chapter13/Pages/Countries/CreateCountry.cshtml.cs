using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker_Chapter13.Interfaces;

namespace RazorPagesEventMaker_Chapter13
{
    public class CreateCountryModel : PageModel
    {
        ICountryRepository repo;
        [BindProperty]
        public Country Country { get; set; }
        public CreateCountryModel(ICountryRepository repository)
        {
            repo = repository;
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
            repo.AddCountry(Country);
            return RedirectToPage("IndexCountry");
        }
    }
}