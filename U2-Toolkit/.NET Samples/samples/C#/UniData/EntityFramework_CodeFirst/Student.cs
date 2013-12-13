using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFramework_CodeFirst
{
    [Table("STUDENT_NF_SUB", Schema = "ppp")]
    public class Student
    {
        Student()
        {
            Semesters = new HashSet<Semester>();
        }
        [Key]
        public string ID { get; set; }

        public string FNAME { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }

        
    }

    [Table("STUDENT_CGA_MV_SUB", Schema = "ppp")]
    public class Semester
    {
        Semester()
        {
            Courses = new HashSet<Course>();
        }
       
        public string ID { get; set; }

        [Key]
        public int  CGA_MV_KEY { get; set; }

        public string SEMESTER { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }


    [Table("STUDENT_CGA_MS_SUB", Schema = "ppp")]
    public class Course
    {
        Course()
        {

        }

        public string ID { get; set; }

        
        public int CGA_MV_KEY { get; set; }

        [Key]
        public int CGA_MS_KEY { get; set; }

        public string COURSE_NAME { get; set; }

        public string TEACHER { get; set; }

        public virtual Semester Semester { get; set; }


    }

    public class StudentContext : DbContext
    {
        public StudentContext()
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>(); 
            // this will take care of 
            //SELECT Extent1.Id, Extent1.ModelHash FROM dbo.EdmMetadata AS Extent1 ORDER BY Extent1.Id DESC SAMPLE 1 

            modelBuilder.Entity<Student>()
                .Property(s => s.ID)

                .IsRequired();
        }

    }
}
