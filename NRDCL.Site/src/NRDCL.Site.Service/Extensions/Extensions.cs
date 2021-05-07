using NRDCL.Site.Service.Dtos;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Extensions
{
    public static class Extensions
    {
        public static SiteDto AsDto(this SiteEntity siteEntity)
        {
            return new SiteDto
            {
                SiteID = siteEntity.SiteID,
                CustomerCID = siteEntity.CustomerCID,
                SiteName = siteEntity.SiteName,
                Distance = siteEntity.Distance
            };
        }

        public static SiteDto AsDto(this SiteEntity siteEntity, string customerName)
        {
            return new SiteDto
            {
                SiteID = siteEntity.SiteID,
                CustomerCID = siteEntity.CustomerCID,
                SiteName = siteEntity.SiteName,
                Distance = siteEntity.Distance,
                CustomerName = customerName
            };
        }
    }
}