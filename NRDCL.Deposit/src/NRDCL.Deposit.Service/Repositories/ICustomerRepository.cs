﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NRDCL.Deposit.Service.Entities;

namespace NRDCL.Deposit.Service.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerEntity>> GetAsync();
        Task<CustomerEntity> GetByIDAsync(string id);
        Task<bool> CreateAsync(CustomerEntity entity);
        Task<bool> UpdateAsync(CustomerEntity entity);
        Task<bool> DeleteAsync(CustomerEntity entity);
    }
}
