using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string JsonFileName)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Event>>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
