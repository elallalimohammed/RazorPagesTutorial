using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesEventMaker_Chapter13
{
    public class IndexModel : PageModel
    {
        IEventRepository repo;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexModel(IEventRepository repository)
        {
            repo = repository;
        }

        public List<Event> Events { get; private set; }
        public IActionResult OnGet()
        {
            Events = repo.GetAllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }
            return Page();
        }
    }
}