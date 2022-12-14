using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.Sql
{
    public class SuperMarketDbContext : DbContext
    {
        public SuperMarketDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(y => y.Category)
                .HasForeignKey(y => y.CategoryId);

            // seeding data example
            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Books",
                        Description = "Books category example"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Cars",
                        Description = "Cars category example"
                    },
                   new Category
                   {
                       CategoryId = 3,
                       Name = "Sports",
                       Description = "Sports category example"
                   }
            );

            modelBuilder.Entity<Product>().HasData(
                 new Product()
                 {
                     ProductId = 1,
                     CategoryId = 1,
                     Name = "Adventures of Tom Sowyer",
                     Quantity = 15,
                     Price = 12.53m
                 },
                 new Product()
                 {
                     ProductId = 2,
                     CategoryId = 2,
                     Name = "BMW Toy",
                     Quantity = 35,
                     Price = 18.35m
                 },
                 new Product()
                 {
                     ProductId = 3,
                     CategoryId = 1,
                     Name = "Vinni Poof",
                     Quantity = 27,
                     Price = 5.77m
                 });
        }
    }
}