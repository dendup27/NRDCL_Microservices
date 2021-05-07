using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NRDCL.Deposit.Service.Dtos
{
    public class DepositDto
    {
        [Key]
        public string CustomerCID { get; set; }
        public decimal LastAmount { get; set; }
        public decimal Balance { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }
    }
}
