﻿using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Allegory.Module.Customers;

public class CustomerManager : DomainService
{
    protected IRepository<Customer, Guid> CustomerRepository { get; }
    protected IRepository<CustomerGroup, Guid> CustomerGroupRepository { get; }

    public CustomerManager(
        IRepository<Customer, Guid> customerRepository,
        IRepository<CustomerGroup, Guid> customerGroupRepository)
    {
        CustomerRepository = customerRepository;
        CustomerGroupRepository = customerGroupRepository;
    }

    public virtual async Task<CustomerGroup> CreateCustomerGroupAsync(string code, string description = default)
    {
        //TODO Add repository method CustomerGroupRepository.FindByCode
        var existingCustomerGroup = await CustomerGroupRepository.FirstOrDefaultAsync(cg => cg.Code == code);
        if (existingCustomerGroup != null)
            throw new UserFriendlyException($"{code} kodlu müşteri grubu zaten kayıtlı");

        var customerGroup = new CustomerGroup(GuidGenerator.Create(), code, description: description);

        return customerGroup;
    }

    public virtual async Task ChangeCustomerGroupCodeAsync(CustomerGroup customerGroup, string code)
    {
        //TODO Add repository method CustomerGroupRepository.FindByCode
        var existingCustomerGroup = await CustomerGroupRepository.FirstOrDefaultAsync(cg => cg.Code == code);
        if (existingCustomerGroup != null && existingCustomerGroup.Id != customerGroup.Id)
            throw new UserFriendlyException($"{code} kodlu müşteri grubu zaten kayıtlı");

        customerGroup.SetCode(code);
    }

    public virtual async Task SetCustomerGroupAsync(Customer customer, CustomerGroup customerGroup)
    {
        var customerGroupCount = await CustomerRepository.CountAsync(c => c.CustomerGroupId == customerGroup.Id);

        if (customerGroupCount >= 10)
        {
            throw new UserFriendlyException($"{customerGroup.Code} kodlu müşteri grubuna 10'dan fazla müşteri bağlanamaz");
        }

        customer.CustomerGroupId = customerGroup.Id;
    }

    public virtual async Task<CustomerGroup> SetCustomerGroupAsync(Customer customer, string customerGroupCode)
    {
        //TODO Add repository method CustomerGroupRepository.FindByCode
        var customerGroup = await CustomerGroupRepository.FirstOrDefaultAsync(cg => cg.Code == customerGroupCode);
        if (customerGroup == null)
            throw new UserFriendlyException($"{customerGroupCode} kodlu müşteri grubu bulunamadı");

        await SetCustomerGroupAsync(customer, customerGroup);

        return customerGroup;
    }
}
