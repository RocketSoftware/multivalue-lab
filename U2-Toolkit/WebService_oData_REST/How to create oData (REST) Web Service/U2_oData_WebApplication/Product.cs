using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Services.Common;

namespace U2_oData_WebApplication
{

    


    [Table("PRODUCTS")]
    [DataServiceKey("ProductId")]
    public class Product
    {
        public Product()
        {
            Awards = new HashSet<Award>();
        }
        
        [Column("PRODUCT_ID")]
        public decimal ProductId { get; set; }
        [Column("TITLE")]
        public string Title { get; set; } //Single Value
        [Column("RATING")]
        public string Rating { get; set; } //Single Value

        [Column("MOVIE_IMAGE")]
        public string Image { get; set; } //Single Value
        public virtual ICollection<Award> Awards { get; set; }
        
    }

    [Table("PRODUCTS_AWARD_INFO")]
    [DataServiceKey("ProductId", "ASSOC_ROW")]
    
    public class Award
    {
        public Award()
        {

        }
        
        [Column("@ASSOC_ROW")]
        public decimal ASSOC_ROW { get; set; }

        
        [Column("PRODUCT_ID")]
        public decimal ProductId { get; set; }
        [Column("AWARD_NAME")]
        public string AwardName { get; set; } //multi-value
        [Column("AWARD_TYPE")]
        public string AwardType { get; set; } //multi-value
         [ForeignKey("ProductId")] 
        public virtual Product Product { get; set; }

        //public Product Product { get; set; }

    }

    public class ProductContext : DbContext
    {
        public ProductContext()
        {
            this.Configuration.ProxyCreationEnabled = false; 
        }

        public DbSet<Product> Products { get; set; }
         public DbSet<Award> Awards { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<Award>().HasKey(u => new
            {
                u.ASSOC_ROW,
                u.ProductId
            });

            modelBuilder.Entity<Product>().HasKey(u => new
            {
                
                u.ProductId
            });
        }
    }

    

}