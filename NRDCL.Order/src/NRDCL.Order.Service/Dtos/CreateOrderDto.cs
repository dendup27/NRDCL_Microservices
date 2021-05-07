using System.ComponentModel.DataAnnotations;

namespace NRDCL.Order.Service.Dtos
{
    public class CreateOrderDto
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Customer is mandatory."), Display(Name = "Customer CID")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} must have a minimum and maximum length of {1}.")]
        public string CustomerCID { get; set; }

        public decimal PriceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public decimal AdvanceBalance { get; set; }

        [Display(Name = "Site"), Required(ErrorMessage = "Site is mandatory.")]
        public int SiteID { get; set; }
        [Display(Name = "Product"), Required(ErrorMessage = "Product is mandatory.")]
        public int ProductID { get; set; }
        [Display(Name = "Quantity"), Required(ErrorMessage = "Quantity is mandatory.")]
        public decimal Quantity { get; set; }
    }
}
