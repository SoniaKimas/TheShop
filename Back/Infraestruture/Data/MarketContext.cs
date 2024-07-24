using Domain;
using Domain.Enums;
using Infraestruture.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Data;
public class MarketContext(DbContextOptions<MarketContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Discount>(entity =>
        {
            entity.Property(p => p.Percentage).HasColumnType("decimal(18,2)");
            entity.Property(p=>p.ProductId).IsRequired();
            entity.Property(p=>p.ProductId).HasColumnType("varchar(255)");
            entity.Property(p=>p.SourceProductId).HasColumnType("varchar(255)");
            entity.Property(p => p.Percentage).HasColumnType("decimal(5,2)");
        });

        builder.Entity<Discount>().HasData(
            new Discount
            {
                Id = 1,
                Type = DiscountType.Direct,
                ProductId = "apple",
                SourceProductId = null,
                Percentage = 10m,
                SourceRequiredQuantity = 1,
                StartDate = DateTime.Now.StartOfCurrentWeek(), // just to seed data
                EndDate = DateTime.Now.EndOfCurrentWeek(), // just to seed data
                IsActive = true
            },
            new Discount
            {
                Id = 2,
                Type = DiscountType.Conditional,
                ProductId = "bread",
                SourceProductId = "soup",
                Percentage = 50m,
                SourceRequiredQuantity = 2,
                StartDate = new DateTime(2021, 1, 1),
                EndDate = new DateTime(2021, 12, 31),
                IsActive = true
            }
        );

        builder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });

        builder.Entity<Product>().HasData(
            new Product
            {
                Id = "soup",
                Name = "Soup",
                ImageUrl = "soup.jpg",
                Price = 0.65m,
                IsAvailable = true,
                UnitType = UnitType.Default
            },
            new Product
            {
                Id = "bread",
                Name = "Bread",
                ImageUrl = "bread.jpg",
                Price = 0.80m,
                IsAvailable = true,
                UnitType = UnitType.Default
            },
            new Product
            {
                Id = "milk",
                Name = "Milk",
                ImageUrl = "milk.jpg",
                Price = 1.30m,
                IsAvailable = true,
                UnitType = UnitType.Default
            },
            new Product
            {
                Id = "apple",
                Name = "Apples Bag",
                ImageUrl = "apples.jpg",
                Price = 1.00m,
                IsAvailable = true,
                UnitType = UnitType.Bag
            }
        );
    }
}