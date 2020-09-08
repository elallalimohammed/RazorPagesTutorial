using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker
{
    public class IndexModel : PageModel
    {
        private FakeEventRepository repo;
        public List<Event> Events { get; private set; }
        public IndexModel()
        {
            repo = new FakeEventRepository();
        }
        public void OnGet()
        {
            Events = repo.GetAllEvents();
        }
    }
}

