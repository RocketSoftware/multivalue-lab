using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFramework_CodeFirst
{

    //[Table("CUSTOMER", Schema = "HS_SALES")] //UNDK-24
    [Table("CUSTOMER")]
    public class Customer
    {
        Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int CUSTID { get; set; }

        public string FNAME { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    //[Table("CUSTOMER_ORDERS", Schema = "HS_SALES")]
    [Table("CUSTOMER_ORDERS")]
    public class Order
    {
        Order()
        {
        }

        [Key]
        [Column("@ASSOC_ROW")]
        public decimal @ASSOC_ROW { get; set; }
        
        public int CUSTID { get; set; }
        public string PRODID { get; set; }
        public string SER_NUM { get; set; }

        public virtual Customer Customer { get; set; }

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
            modelBuilder.Entity<Customer>()
                .Property(s => s.FNAME)
                .IsRequired();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>(); 
        }

    }



}
