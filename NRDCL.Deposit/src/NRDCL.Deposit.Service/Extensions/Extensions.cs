using NRDCL.Deposit.Service.Dtos;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Extensions
{
    public static class Extensions
    {
        public static DepositDto AsDto(this DepositEntity deposit)
        {
            return new DepositDto
            {
                CustomerCID = deposit.CustomerCID,
                LastAmount = deposit.LastAmount,
                Balance = deposit.Balance
            };
        }

        public static DepositDto AsDto(this DepositEntity deposit, string customerName)
        {
            return new DepositDto
            {
                CustomerCID = deposit.CustomerCID,
                LastAmount = deposit.LastAmount,
                Balance = deposit.Balance,
                CustomerName = customerName
            };
        }
    }
}