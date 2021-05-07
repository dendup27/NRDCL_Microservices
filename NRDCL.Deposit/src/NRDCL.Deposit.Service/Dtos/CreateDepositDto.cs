using System.ComponentModel.DataAnnotations;

namespace NRDCL.Deposit.Service.Dtos
{
    public class CreateDepositDto
    {
        [Key]
        public string CustomerCID { get; set; }
        public decimal LastAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
