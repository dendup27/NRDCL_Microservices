namespace NRDCL.Common.Dtos.Product
{
    public class ProductDeleted
    {
        public int ProductID { get; set; }

        public ProductDeleted(int ProductID)
        {
            this.ProductID = ProductID;
        }
    }
}
