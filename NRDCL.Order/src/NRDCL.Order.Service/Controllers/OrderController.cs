using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NRDCL.Order.Service.Dtos;
using NRDCL.Order.Service.Extensions;
using NRDCL.Order.Service.Entities;
using MassTransit;
using NRDCL.Order.Service.Repositories;
using NRDCL.Common.Dtos.Customer;

namespace NRDCL.Order.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
        }

        //GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAsync()
        {
            return Ok((await _orderRepository.GetAsync()).Select(item => item.AsDto()));
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetByIDAsync(int id)
        {
            var order = await _orderRepository.GetByIDAsync(id);
            return order != null ? order.AsDto() : NotFound();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostAsync(CreateOrderDto createOrderDto)
        {
            var order = new OrderEntity
            {
                OrderID = createOrderDto.OrderID,
                CustomerCID = createOrderDto.CustomerCID,
                PriceAmount = createOrderDto.PriceAmount,
                TransportAmount = createOrderDto.TransportAmount,
                AdvanceBalance = createOrderDto.AdvanceBalance
            };

            await _orderRepository.CreateAsync(order);
            // await _publishEndpoint.Publish(new CustomerCreated(
            //     customer.CustomerCID, customer.CustomerName, customer.MobileNumber, customer.MailAddress
            // ));
            return CreatedAtAction(nameof(GetByIDAsync), new { id = order.OrderID }, order);
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, CreateOrderDto createOrderDto)
        {
            var order = await _orderRepository.GetByIDAsync(id);

            if (order == null)
                return NotFound();

            order.CustomerCID = createOrderDto.CustomerCID;
            order.PriceAmount = createOrderDto.PriceAmount;
            order.TransportAmount = createOrderDto.TransportAmount;
            order.AdvanceBalance = createOrderDto.AdvanceBalance;

            await _orderRepository.UpdateAsync(order);
            // await _publishEndpoint.Publish(new CustomerUpdated(
            //     customer.CustomerCID, customer.CustomerName, customer.MobileNumber, customer.MailAddress
            // ));
            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIDAsync(id);

            if (order == null)
                return NotFound();

            await _orderRepository.DeleteAsync(order);
            await _publishEndpoint.Publish(new CustomerDeleted(order.CustomerCID));
            return NoContent();
        }
    }
}
