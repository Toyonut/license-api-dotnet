using System.Collections.Generic;

namespace LicenseData
{
    public interface ILicenseProvider
    {
        List<string> GetAvailableLicenseIDs();
        License GetLicense(string id);
        string ReplaceYear();
    }
}