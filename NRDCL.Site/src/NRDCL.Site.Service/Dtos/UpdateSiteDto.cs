using System.ComponentModel.DataAnnotations;

namespace NRDCL.Site.Service.Dtos
{
    public class UpdateSiteDto
    {
        [Key]
        public int SiteID { get; set; }

        [Required(ErrorMessage = "Customer CID is mandatory.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Customer CID must have a minimum and maximum length of 11.")]
        [Display(Name = "Customer CID")]
        public string CustomerCID { get; set; }

        [Required(ErrorMessage = "Site name is mandatory.")]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "Site Name")]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "Distance is mandatory.")]
        [RegularExpression("^(0*[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*)$", ErrorMessage = "Please enter a valid distance.")]
        [Display(Name = "Distance")]
        public double Distance { get; set; }
    }
}
