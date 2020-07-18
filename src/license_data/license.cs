using System;

namespace license_data
{
    public class license 
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
