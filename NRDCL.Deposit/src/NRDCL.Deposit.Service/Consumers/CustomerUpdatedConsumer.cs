using System.Threading.Tasks;
using MassTransit;
using NRDCL.Common.Dtos.Customer;
using NRDCL.Deposit.Service.Repositories;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Consumers
{
    public class CustomerUpdatedConsumer : IConsumer<CustomerUpdated>
    {
        private readonly ICustomerRepository _repository;

        public CustomerUpdatedConsumer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CustomerUpdated> context)
        {
            var message = context.Message;
            var customer = await _repository.GetByIDAsync(message.CustomerCID);

            if (customer == null)
            {
                customer = new CustomerEntity
                {
                    CustomerCID = message.CustomerCID,
                    CustomerName = message.CustomerName,
                    MobileNumber = message.MobileNumber,
                    MailAddress = message.MailAddress
                };

                await _repository.CreateAsync(customer);
            }
            else
            {
                customer.CustomerName = message.CustomerName;
                customer.MobileNumber = message.MobileNumber;
                customer.MailAddress = message.MailAddress;

                await _repository.UpdateAsync(customer);
            }
        }
    }
}