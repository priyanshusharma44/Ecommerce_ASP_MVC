using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_ASPDOTNET_MVC.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //pass connection string
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //ttable that create in database automatically 
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Action", DisplayOrder = 3 }

                );
        }

    }
}
