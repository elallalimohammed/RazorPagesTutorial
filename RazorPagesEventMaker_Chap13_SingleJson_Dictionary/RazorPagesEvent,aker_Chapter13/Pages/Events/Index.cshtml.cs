using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker_Chapter13.Interfaces;

namespace RazorPagesEventMaker_Chapter13
{
    public class IndexModel : PageModel
    {
        IEventRepository repo;
        public IndexModel(IEventRepository repository)
        {
            repo = repository;
        }
        public Dictionary<int, Event> Events { get; private set; }       
        public IActionResult OnGet()
        {           
            Events = repo.GetAllEvents();
            return Page();
        }
    }
}