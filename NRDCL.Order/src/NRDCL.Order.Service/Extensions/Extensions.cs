using NRDCL.Order.Service.Dtos;
using NRDCL.Order.Service.Entities;

namespace NRDCL.Order.Service.Extensions
{
    public static class Extensions
    {
        public static OrderDto AsDto(this OrderEntity orderEntity)
        {
            return new OrderDto
            {
                OrderID = orderEntity.OrderID,
                CustomerCID = orderEntity.CustomerCID,
                PriceAmount = orderEntity.PriceAmount,
                TransportAmount = orderEntity.TransportAmount,
                AdvanceBalance = orderEntity.AdvanceBalance
            };
        }
    }
}