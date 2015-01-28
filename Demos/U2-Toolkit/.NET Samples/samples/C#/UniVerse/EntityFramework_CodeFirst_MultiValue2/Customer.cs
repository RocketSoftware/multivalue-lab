using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFramework_CodeFirst_MultiValue2
{
    
    public class Customer
    {
        Customer()
        {
        }

        [Key]
        [Column("CUSTID")]
        public int ID { get; set; }
        [Column("FNAME")]
        public string FirstName { get; set; } //Single Value
        [Column("LNAME")]
        public string LastName { get; set; } //Single Value
        public virtual Order Orders { get; set; }
        
    }

    public class Order
    {
        Order()
        {
        }

        [Key]
        [Column("CUSTID")]
        public int ID { get; set; }
        
        [Column("PRICE")]
        public int Price { get; set; } //Multi Value
        [Column("BUY_DATE")]
        public DateTime BuyDate { get; set; } //Multi Value
    }

    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Customer>().HasRequired(c => c.Orders).WithRequiredPrincipal();
            modelBuilder.Entity<Customer>().ToTable("CUSTOMER");
            modelBuilder.Entity<Order>().ToTable("CUSTOMER");
        }
    }

}
