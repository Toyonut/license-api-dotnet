using System.Collections.Generic;

namespace LicenseData
{
    public class License
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string LicenseText { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Conditions { get; set; }
        public List<string> Limitations { get; set; }
    }
}