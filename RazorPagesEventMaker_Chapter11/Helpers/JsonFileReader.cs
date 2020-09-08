using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter11
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Event>>(jsonString);
        }
    }
}
