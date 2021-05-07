using System.ComponentModel.DataAnnotations;

namespace NRDCL.Deposit.Service.Entities
{
    public class DepositEntity
    {
        [Key]
        public string CustomerCID { get; set; }
        public decimal LastAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
