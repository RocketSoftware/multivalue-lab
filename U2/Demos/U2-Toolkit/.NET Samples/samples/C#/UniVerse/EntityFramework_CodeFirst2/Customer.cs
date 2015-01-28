using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFramework_CodeFirst2
{
    public class Customer
    {
        Customer()
        {
        }

        [Key]
        public int CUSTID { get; set; }

        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string FULLADDR { get; set; }
    }

    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(s => s.FNAME)
                
                .IsRequired();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>(); 
        }
    }



}
