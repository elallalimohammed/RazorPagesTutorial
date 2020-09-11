using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker_Chapter13;

namespace RazorPagesEventMaker_Chapter13
{
    public class CountryEventsModel : PageModel
    {
        IEventRepository repo;
        public Dictionary<int,Event> Events { get; private set; }
        public CountryEventsModel(IEventRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(string code)
        {
            Events = new Dictionary<int, Event>();
            if (code == null)
            {
                return NotFound();
            }
            Events = repo.SearchEventsByCode(code);
            if (Events == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}