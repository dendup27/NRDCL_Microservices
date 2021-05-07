using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NRDCL.Order.Service.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Customer is mandatory."), Display(Name = "Customer CID")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} must have a minimum and maximum length of {1}.")]
        public string CustomerCID { get; set; }

        public decimal PriceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public decimal AdvanceBalance { get; set; }

        [NotMapped, Display(Name = "Site"), Required(ErrorMessage = "Site is mandatory.")]
        public int SiteID { get; set; }
        [NotMapped, Display(Name = "Product"), Required(ErrorMessage = "Product is mandatory.")]
        public int ProductID { get; set; }
        [NotMapped, Display(Name = "Quantity"), Required(ErrorMessage = "Quantity is mandatory.")]
        public decimal Quantity { get; set; }
    }
}
