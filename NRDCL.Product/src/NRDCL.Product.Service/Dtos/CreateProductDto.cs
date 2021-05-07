using System.ComponentModel.DataAnnotations;

namespace NRDCL.Product.Service.Dtos
{
    public class CreateProductDto
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is mandatory.")]
        [StringLength(250, MinimumLength = 3)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is mandatory."), Display(Name = "Price")]
        [RegularExpression("^(0*[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*)$", ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Rate is mandatory."), Display(Name = "Rate")]
        [RegularExpression("^(0*[1-9][0-9]*(\\.[0-9]+)?|0+\\.[0-9]*[1-9][0-9]*)$", ErrorMessage = "Please enter a valid rate.")]
        public decimal Rate { get; set; }
    }
}
