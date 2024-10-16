namespace Cyber_Proj.Models
{
    public class VirusTotalResult
    {
        public string ScanId { get; set; }
        public string Resource { get; set; }
        public string Url { get; set; }
        public string ScanDate { get; set; }
        public string Permalink { get; set; }
        public int Positives { get; set; }
        public int Total { get; set; }
        public ScanReport Scans { get; set; }
    }

    public class ScanReport
    {
        public ScanEngineDetails BitDefender { get; set; }
        public ScanEngineDetails Kaspersky { get; set; }
        // Add more scan engines based on the API response.
    }

    public class ScanEngineDetails
    {
        public string Detected { get; set; }
        public string Version { get; set; }
        public string Result { get; set; }
    }
}
