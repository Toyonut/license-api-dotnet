using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace license_loader
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("./data/all_licenses.json");
            var licenses = JsonSerializer.Deserialize<List<license>>(jsonString);

            Console.WriteLine(licenses[0].conditions[0]);
        }
    }

    class license 
    {
        public string id { get; set; }
        public string name { get; set; }
        public string licenseText { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public List<string> permissions { get; set; }
        public List<string> conditions { get; set; }
        public List<string> limitations { get; set; }
    }
}
