﻿using System.Data.Entity;
using PHP.Sales.Core.Models.System;
using PHP.Sales.DataAccess.Configurations;

namespace PHP.Sales.DataAccess
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext() 
            :base("sales.db")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Stock> StockSnapshot { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SaleConfiguration());
            modelBuilder.Configurations.Add(new ReportConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
