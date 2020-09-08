using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker.Models
{
    public class Event
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }	
		public DateTime DateTime { get; set; }
	}
}
