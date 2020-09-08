using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesEventMaker_Chapter13
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

        public IActionResult OnPost(int id)
        {
            if (id != null)
            {
                repo.DeleteEvent(id);
            }

            return RedirectToPage("Index");
        }

    }
}