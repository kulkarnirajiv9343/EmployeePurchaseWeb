using EmployeePurchaseWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace EmployeePurchaseWeb.Data
{
    public class EmpPurchaseDbContext : DbContext
    {
        public EmpPurchaseDbContext() : base("name=EmpPurchaseDBConnection")
        {

        }
        public DbSet<Purchase> Purchases { get; set; }
    }
}