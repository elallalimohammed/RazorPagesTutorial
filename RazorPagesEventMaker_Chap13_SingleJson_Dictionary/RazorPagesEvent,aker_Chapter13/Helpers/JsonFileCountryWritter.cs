using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMaker_Chapter13.Helpers
{
    public class JsonFileCountryWritter
    {
        public static void WriteToJson(Dictionary<string, Country> countries, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(countries, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
