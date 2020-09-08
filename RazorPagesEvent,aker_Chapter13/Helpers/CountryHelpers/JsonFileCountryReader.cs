using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter13
{
    public class JsonFileCountryReader
    {
        public static List<Country> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Country>>(jsonString);
        }
    }
}
