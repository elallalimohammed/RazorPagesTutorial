using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorpagesEventMaker_Chapter10;
using RazorPagesEventMaker_Chapter10.Interfaces;

namespace RazorPagesEventMaker_Chapter10
{
    public class CreateEventModel : PageModel
    {
        IEventRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public CreateEventModel(IEventRepository repository)
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
                return Page();
            }
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }
    }
}