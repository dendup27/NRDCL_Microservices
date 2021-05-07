namespace NRDCL.Common.Dtos.Deposit
{
    public class DepositDeleted
    {
        public string CustomerCID { get; set; }

        public DepositDeleted(string CustomerCID)
        {
            this.CustomerCID = CustomerCID;
        }
    }
}
