using System.Threading.Tasks;
using MassTransit;
using NRDCL.Common.Dtos.Customer;
using NRDCL.Site.Service.Repositories;
using NRDCL.Site.Service.Entities;

namespace NRDCL.Site.Service.Consumers
{
    public class CustomerDeletedConsumer : IConsumer<CustomerDeleted>
    {
        private readonly ICustomerRepository _repository;

        public CustomerDeletedConsumer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<CustomerDeleted> context)
        {
            var message = context.Message;
            var customer = await _repository.GetByIDAsync(message.CustomerCID);

            if (customer == null)
            {
                return;
            }

            await _repository.DeleteAsync(customer);
        }
    }
}