using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LicenseData
{
    public class LicenseContext : DbContext
    {
        public DbSet<License> licenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;database=licensedata;user id=postgres; password=pass@word1");
        }
    }

    public class License 
    {
        private LicenseContext _dbContext;
        public License()
        {
            _dbContext = new LicenseContext();
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string LicenseText { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Conditions { get; set; }
        public List<string> Limitations { get; set; }

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
    }
}
