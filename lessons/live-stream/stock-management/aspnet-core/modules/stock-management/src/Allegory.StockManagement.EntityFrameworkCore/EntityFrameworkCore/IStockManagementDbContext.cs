﻿using Allegory.StockManagement.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.EntityFrameworkCore;

[ConnectionStringName(StockManagementDbProperties.ConnectionStringName)]
public interface IStockManagementDbContext : IEfCoreDbContext
{
     DbSet<Customer> Customers { get; }
}
