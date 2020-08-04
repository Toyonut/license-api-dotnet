using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace LicenseData
{
    public class PostgresLicenseContext : DbContext
    {
        public DbSet<License> licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;database=licensedata;user id=postgres; password=pass@word1");
        }
    }

    public class PostgresLicenseProvider : ILicenseProvider
    {
        private PostgresLicenseContext _dbContext;

        public PostgresLicenseProvider()
        {
            _dbContext = new PostgresLicenseContext();
        }

        public List<string> GetAvailableLicenseIDs ()
        {
            return _dbContext.licenses.Select( l => l.ID ).ToList();
        }

        public License GetLicense (string id)
        {
            return _dbContext.licenses
                    .Where(l => l.ID == id)
                    .Single();
        }

        public string ReplaceYear (string licenseText)
        {
            string searchPattern = @"\[year\]";
            string replacementValue = DateTime.Now.Year.ToString();
            return Regex.Replace(licenseText, searchPattern, replacementValue);
        }
    }
}
