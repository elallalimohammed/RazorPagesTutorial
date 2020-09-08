using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileWritter
    {
        public static void WriteToJson(List<Event> @events, string JsonFileName)
        {
            using (FileStream outputStream = File.OpenWrite(JsonFileName))
            {
                var writter = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(writter, @events.ToArray()); 
                
            }
        }
    }
}
