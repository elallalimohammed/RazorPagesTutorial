using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker
{
    public class EditEventModel : PageModel
    {
        IEventRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public EditEventModel(IEventRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Event= repo.GetEvent(id);
            if (Event == null)
            {
                return null;
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateEvent(Event);
            return RedirectToPage("Index");
        }
    }
}
