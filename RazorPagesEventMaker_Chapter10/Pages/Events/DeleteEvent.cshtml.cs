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
    public class DeleteEventModel : PageModel
    {
        IEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventModel(IEventRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            repo.DeleteEvent(Event);
            return RedirectToPage("Index");
        }

    }
}