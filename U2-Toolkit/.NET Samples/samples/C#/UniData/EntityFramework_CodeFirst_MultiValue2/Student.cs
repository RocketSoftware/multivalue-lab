using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFramework_CodeFirst_MultiValue2
{
    
    public class Student
    {
        Student()
        {
        }

        [Key]
        [Column("ID")]
        public string StudentID { get; set; }  
        [Column("FNAME")]
        public string FirstName { get; set; } //Single Value
        [Column("LNAME")]
        public string LastName { get; set; } //Single Value

        public virtual Semester Semesters { get; set; }
        

    }
    public class Semester
    {
        Semester()
        {
        }

        [Key]
        [Column("ID")]
        public string StudentID { get; set; }  
        [Column("SEMESTER")]
        public string StudentSemester { get; set; } //Multi Value

    }

    public class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Student>().HasRequired(c => c.Semesters).WithRequiredPrincipal();
            modelBuilder.Entity<Student>().ToTable("STUDENT");
            modelBuilder.Entity<Semester>().ToTable("STUDENT");
        }
    }
}
