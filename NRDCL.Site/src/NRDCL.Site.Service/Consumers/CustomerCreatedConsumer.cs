using System.Threading.Tasks;
using MassTransit;
using NRDCL.Common.Dtos.Customer;
using NRDCL.Site.Service.Repositories;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Consumers
{
    public class CustomerCreatedConsumer : IConsumer<CustomerCreated>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreatedConsumer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Consume(ConsumeContext<CustomerCreated> context)
        {
            var message = context.Message;
            var customer = await _customerRepository.GetByIDAsync(message.CustomerCID);

            if (customer != null)
            {
                return;
            }

            customer = new CustomerEntity
            {
                CustomerCID = message.CustomerCID,
                CustomerName = message.CustomerName,
                MobileNumber = message.MobileNumber,
                MailAddress = message.MailAddress
            };

            await _customerRepository.CreateAsync(customer);
        }
    }
}