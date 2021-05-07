using NRDCL.Customer.Service.Dtos;
using NRDCL.Customer.Service.Entities;

namespace NRDCL.Customer.Service.Extensions
{
    public static class Extensions
    {
        public static CustomerDto AsDto(this CustomerEntity customer)
        {
            return new CustomerDto
            {
                CustomerCID = customer.CustomerCID,
                CustomerName = customer.CustomerName,
                MobileNumber = customer.MobileNumber,
                MailAddress = customer.MailAddress
            };
        }
    }
}