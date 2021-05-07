namespace NRDCL.Common.Dtos.Product
{
    public class ProductUpdated
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }

        public ProductUpdated(int ProductID, string ProductName, decimal Price, decimal Rate)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.Price = Price;
            this.Rate = Rate;
        }
    }
}
