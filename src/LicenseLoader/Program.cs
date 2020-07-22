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
            
            var seriaizerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            };
            var licenses = JsonSerializer.Deserialize<List<License>>(jsonString, seriaizerOptions);

            Console.WriteLine(licenses[0].Conditions[0]);

            var dbContext = new LicenseContext();

            foreach (var licence in licenses)
            {
                dbContext.Add(licence);
                dbContext.SaveChanges();
            }

        }
    }
}
