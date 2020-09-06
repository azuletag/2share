using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GroceryContext : DbContext
    {
        public GroceryContext() : base("GroceryContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }

        //public DbSet<ProductGroceryList> ProductGroceryLists { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
