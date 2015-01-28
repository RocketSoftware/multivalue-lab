using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace EntityFramework_CodeFirst2
{
    public class Student
    {
        Student()
        {
        }

        [Key]
        public int ID { get; set; }

        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string MAJOR { get; set; }
        public string MINOR { get; set; }
    }

    public class StudentContext : DbContext
    {
        public StudentContext()
        {
        }
        public DbSet<Student> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.ID)

                .IsRequired();
        }
    }




}
