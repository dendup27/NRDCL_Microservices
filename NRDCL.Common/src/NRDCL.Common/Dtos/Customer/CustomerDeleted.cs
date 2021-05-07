namespace NRDCL.Common.Dtos.Customer
{
    public class CustomerDeleted
    {
        public string CustomerCID { get; set; }

        public CustomerDeleted(string CustomerCID)
        {
            this.CustomerCID = CustomerCID;
        }
    }
}
