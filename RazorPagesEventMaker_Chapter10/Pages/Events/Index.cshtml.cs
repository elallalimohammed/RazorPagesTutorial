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
    public class IndexModel : PageModel
    {
        IEventRepository repo;
        public List<Event> Events { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexModel(IEventRepository repository)
        {
            repo = repository;
        }
        public void OnGet()
        {
            Events = repo.GetAllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }
        }
    }
}