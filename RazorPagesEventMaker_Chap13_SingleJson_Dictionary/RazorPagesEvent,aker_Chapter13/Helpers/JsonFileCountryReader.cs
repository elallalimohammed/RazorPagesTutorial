using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter13.Helpers
{
    public class JsonFileCountryReader
    {
        public static Dictionary<string,Country> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<string,Country>>(jsonString);
        }
    }
}
