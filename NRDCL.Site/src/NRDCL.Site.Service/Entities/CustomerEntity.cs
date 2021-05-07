using System.ComponentModel.DataAnnotations;

namespace NRDCL.Site.Service.Entities
{
    public class CustomerEntity
    {
        [Key]
        public string CustomerCID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
