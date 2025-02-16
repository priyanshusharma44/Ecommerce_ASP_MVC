using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce_ASPDOTNET_MVC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companys { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Drama", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Adventure", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                }
                
          );
            modelBuilder.Entity<Company>().HasData(
    new Company
    {
        Id = 1,
        Name = "Tech Innovators",
        StreetAddress = "123 Tech Street",
        City = "Kathmandu",
        Street = "Tech Lane",
        PostalCode = "44600",
        PhoneNumber = "9841234567"
    },
    new Company
    {
        Id = 2,
        Name = "Smart Solutions",
        StreetAddress = "456 IT Park",
        City = "Pokhara",
        Street = "Innovation Road",
        PostalCode = "33700",
        PhoneNumber = "9856789102"
    },
    new Company
    {
        Id = 3,
        Name = "Future Enterprises",
        StreetAddress = "789 Business Avenue",
        City = "Biratnagar",
        Street = "Enterprise Road",
        PostalCode = "56600",
        PhoneNumber = "9812345678"
    },
    new Company
    {
        Id = 4,
        Name = "NextGen Technologies",
        StreetAddress = "101 AI Boulevard",
        City = "Lalitpur",
        Street = "Machine Learning St",
        PostalCode = "44700",
        PhoneNumber = "9801122334"
    },
new Company
{
    Id = 5,
    Name = "Cloud Solutions",
    StreetAddress = "202 Cloud Drive",
    City = "Bhaktapur",
    Street = "Virtual Way",
    PostalCode = "44800",
    PhoneNumber = "9822233445"
},
new Company
{
    Id = 6,
    Name = "Digital Horizons",
    StreetAddress = "303 Cyber Street",
    City = "Chitwan",
    Street = "Web Innovation Road",
    PostalCode = "44200",
    PhoneNumber = "9845566778"
},
new Company
{
    Id = 7,
    Name = "IT Hub Nepal",
    StreetAddress = "404 Silicon Valley",
    City = "Dharan",
    Street = "Tech Park Lane",
    PostalCode = "56700",
    PhoneNumber = "9867788990"
},
new Company
{
    Id = 8,
    Name = "ByteCode Solutions",
    StreetAddress = "505 Software Avenue",
    City = "Hetauda",
    Street = "Programming Street",
    PostalCode = "44107",
    PhoneNumber = "9811122334"
},
new Company
{
    Id = 9,
    Name = "AI Revolution",
    StreetAddress = "606 Neural Street",
    City = "Butwal",
    Street = "Deep Learning Lane",
    PostalCode = "44500",
    PhoneNumber = "9854455667"
},
new Company
{
    Id = 10,
    Name = "Quantum Computing Ltd.",
    StreetAddress = "707 Quantum Road",
    City = "Damak",
    Street = "AI Research Ave",
    PostalCode = "57300",
    PhoneNumber = "9843344556"
},
new Company
{
    Id = 11,
    Name = "Innovate Nepal",
    StreetAddress = "808 Future Street",
    City = "Janakpur",
    Street = "Startup Avenue",
    PostalCode = "45600",
    PhoneNumber = "9862233445"
},
new Company
{
    Id = 12,
    Name = "Cyber Security Experts",
    StreetAddress = "909 Firewall Road",
    City = "Birgunj",
    Street = "Encryption Lane",
    PostalCode = "44300",
    PhoneNumber = "9813344556"
},
new Company
{
    Id = 13,
    Name = "E-Commerce Nepal",
    StreetAddress = "1010 Shopping Plaza",
    City = "Nepalgunj",
    Street = "Online Store Avenue",
    PostalCode = "44610",
    PhoneNumber = "9846677889"
}

);

        }
    }
}
