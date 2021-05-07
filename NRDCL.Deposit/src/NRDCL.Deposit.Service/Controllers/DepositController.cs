using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Deposit.Service.Dtos;
using NRDCL.Deposit.Service.Extensions;
using NRDCL.Deposit.Service.Entities;
using MassTransit;
using NRDCL.Deposit.Service.Repositories;
using NRDCL.Common.Dtos.Deposit;

namespace NRDCL.Deposit.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : ControllerBase
    {
        private readonly IDepositRepository _depositRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public DepositController(IDepositRepository depositRepository, ICustomerRepository customerRepository,
            IPublishEndpoint publishEndpoint)
        {
            _depositRepository = depositRepository;
            _customerRepository = customerRepository;
            _publishEndpoint = publishEndpoint;
        }

        //GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepositDto>>> GetAsync()
        {
            var customers = await _customerRepository.GetAsync();
            var deposits = (await _depositRepository.GetAsync()).Select(deposit =>
           {
               var customer = customers.Single(customer => customer.CustomerCID == deposit.CustomerCID);
               return deposit.AsDto(customer.CustomerName);
           });

            return Ok(deposits);
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DepositDto>> GetByIDAsync(string id)
        {
            var customer = await _depositRepository.GetByIDAsync(id);
            return customer != null ? customer.AsDto() : NotFound();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<DepositDto>> PostAsync(CreateDepositDto depositDto)
        {
            var deposit = new DepositEntity
            {
                CustomerCID = depositDto.CustomerCID,
                LastAmount = depositDto.LastAmount,
                Balance = depositDto.Balance
            };

            await _depositRepository.CreateAsync(deposit);
            await _publishEndpoint.Publish(new DepositCreated(
                deposit.CustomerCID, deposit.LastAmount, deposit.Balance
            ));
            return CreatedAtAction(nameof(GetByIDAsync), new { id = deposit.CustomerCID }, deposit);
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, UpdateDepositDto depositDto)
        {
            var deposit = await _depositRepository.GetByIDAsync(id);

            if (deposit == null)
                return NotFound();

            deposit.LastAmount = depositDto.LastAmount;
            deposit.Balance = depositDto.Balance;

            await _depositRepository.UpdateAsync(deposit);
            await _publishEndpoint.Publish(new DepositUpdated(
                deposit.CustomerCID, deposit.LastAmount, deposit.Balance
            ));
            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var deposit = await _depositRepository.GetByIDAsync(id);

            if (deposit == null)
                return NotFound();

            await _depositRepository.DeleteAsync(deposit);
            await _publishEndpoint.Publish(new DepositDeleted(deposit.CustomerCID));
            return NoContent();
        }
    }
}
