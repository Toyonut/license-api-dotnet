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
        private License _licenseDefinition;
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
            _licenseDefinition = _dbContext.licenses
                    .Where(l => l.ID == id)
                    .Single();

            return _licenseDefinition;
        }

        public string ReplaceYear ()
        {
            string searchPattern = @"\[year\]";
            string replacementValue = DateTime.Now.Year.ToString();
            return Regex.Replace(_licenseDefinition.LicenseText, searchPattern, replacementValue);
        }
    }
}
