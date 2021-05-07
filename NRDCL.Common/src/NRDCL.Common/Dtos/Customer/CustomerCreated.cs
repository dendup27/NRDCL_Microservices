namespace NRDCL.Common.Dtos.Customer
{
    public class CustomerCreated
    {
        public string CustomerCID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string MailAddress { get; set; }

        public CustomerCreated(string CustomerCID, string CustomerName, string MobileNumber, string MailAddress)
        {
            this.CustomerCID = CustomerCID;
            this.CustomerName = CustomerName;
            this.MobileNumber = MobileNumber;
            this.MailAddress = MailAddress;
        }
    }
}
