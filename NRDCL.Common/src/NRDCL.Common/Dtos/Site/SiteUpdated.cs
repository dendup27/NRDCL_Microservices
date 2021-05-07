namespace NRDCL.Common.Dtos.Site
{
    public class SiteUpdated
    {
        public int SiteID { get; set; }
        public string CustomerCID { get; set; }
        public string SiteName { get; set; }
        public double Distance { get; set; }

        public SiteUpdated(int SiteID, string CustomerCID, string SiteName, double Distance)
        {
            this.SiteID = SiteID;
            this.CustomerCID = CustomerCID;
            this.SiteName = SiteName;
            this.Distance = Distance;
        }
    }
}
