using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Customer.Service.Dtos;
using NRDCL.Customer.Service.Extensions;
using NRDCL.Customer.Service.Entities;
using MassTransit;
using NRDCL.Customer.Service.Repositories;
using NRDCL.Common.Dtos.Customer;

namespace NRDCL.Customer.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerController(ICustomerRepository customerRepository, IPublishEndpoint publishEndpoint)
        {
            _customerRepository = customerRepository;
            _publishEndpoint = publishEndpoint;
        }

        //GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAsync()
        {
            return Ok((await _customerRepository.GetAsync()).Select(item => item.AsDto()));
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetByIDAsync(string id)
        {
            var customer = await _customerRepository.GetByIDAsync(id);
            return customer != null ? customer.AsDto() : NotFound();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new CustomerEntity
            {
                CustomerCID = createCustomerDto.CustomerCID,
                CustomerName = createCustomerDto.CustomerName,
                MobileNumber = createCustomerDto.MobileNumber,
                MailAddress = createCustomerDto.MailAddress
            };

            await _customerRepository.CreateAsync(customer);
            await _publishEndpoint.Publish(new CustomerCreated(
                customer.CustomerCID, customer.CustomerName, customer.MobileNumber, customer.MailAddress
            ));
            return CreatedAtAction(nameof(GetByIDAsync), new { id = customer.CustomerCID }, customer);
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _customerRepository.GetByIDAsync(id);

            if (customer == null)
                return NotFound();

            customer.CustomerName = updateCustomerDto.CustomerName;
            customer.MobileNumber = updateCustomerDto.MobileNumber;
            customer.MailAddress = updateCustomerDto.MailAddress;

            await _customerRepository.UpdateAsync(customer);
            await _publishEndpoint.Publish(new CustomerUpdated(
                customer.CustomerCID, customer.CustomerName, customer.MobileNumber, customer.MailAddress
            ));
            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var customer = await _customerRepository.GetByIDAsync(id);

            if (customer == null)
                return NotFound();

            await _customerRepository.DeleteAsync(customer);
            await _publishEndpoint.Publish(new CustomerDeleted(customer.CustomerCID));
            return NoContent();
        }
    }
}
