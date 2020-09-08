using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorpagesEventMaker_Chapter9_2
{
    public class CreateEventModel : PageModel
    {
        private FakeEventRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public CreateEventModel()
        {
            repo = FakeEventRepository.Instance;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                // try this option
                //return BadRequest(ModelState);
            }
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }
    }
}