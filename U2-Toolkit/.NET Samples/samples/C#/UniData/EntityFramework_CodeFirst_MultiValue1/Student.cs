using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFramework_CodeFirst_MultiValue1
{
    [Table("STUDENT")]
    public class Student
    {
        Student()
        {
        }

        [Key]
        [Column("ID")]
        public string StudentID { get; set; }  //Single Value
        [Column("FNAME")]
        public string FirstName { get; set; } //Single Value
        [Column("LNAME")]
        public string LastName { get; set; } //Single Value
        [Column("SEMESTER")]
        public string Semester { get; set; } //Multi Value

    }
    public class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
