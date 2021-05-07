namespace NRDCL.Common.Dtos.Deposit
{
    public class DepositCreated
    {
        public string CustomerCID { get; set; }
        public decimal LastAmount { get; set; }
        public decimal Balance { get; set; }

        public DepositCreated(string CustomerCID, decimal LastAmount, decimal Balance)
        {
            this.CustomerCID = CustomerCID;
            this.LastAmount = LastAmount;
            this.Balance = Balance;
        }
    }
}
