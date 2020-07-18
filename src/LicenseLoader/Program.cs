using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using LicenseData;

namespace license_loader
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("./data/all_licenses.json");
            var licenses = JsonSerializer.Deserialize<List<License>>(jsonString);

            Console.WriteLine(licenses[0].Conditions[0]);
        }
    }
}
