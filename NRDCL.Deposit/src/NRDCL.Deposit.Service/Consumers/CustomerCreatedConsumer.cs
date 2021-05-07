using System.Threading.Tasks;
using MassTransit;
using NRDCL.Common.Dtos.Customer;
using NRDCL.Deposit.Service.Repositories;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Consumers
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