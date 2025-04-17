using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Seed
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var now = new DateTime(2025, 04, 16, 12, 0, 0, DateTimeKind.Unspecified);

            var adminId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var clientId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var sellerId = Guid.Parse("00000000-0000-0000-0000-000000000003");

            var users = new[]
            {
                new User
                {
                    Id = adminId,
                    Username = "admin.user",
                    Email = "admin@ambev.com",
                    Phone = "+5511999990001",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    Role = UserRole.Admin,
                    Status = UserStatus.Active,
                    CreatedAt = now.AddHours(2)
                },
                new User
                {
                    Id = clientId,
                    Username = "joao.cliente",
                    Email = "joao@cliente.com",
                    Phone = "+5511999990002",
                    Password = BCrypt.Net.BCrypt.HashPassword("Joao@123"),
                    Role = UserRole.None,
                    Status = UserStatus.Active,
                    CreatedAt = now.AddMinutes(10)
                },
                new User
                {
                    Id = sellerId,
                    Username = "vendedor.maria",
                    Email = "maria@vendas.com",
                    Phone = "+5511999990003",
                    Password = BCrypt.Net.BCrypt.HashPassword("Maria@123"),
                    Role = UserRole.Customer,
                    Status = UserStatus.Active,
                    CreatedAt = now.AddMinutes(20)
                }
            };
            // ==== PRODUCTS ====
            var product1Id = Guid.Parse("10000000-0000-0000-0000-000000000001");
            var product2Id = Guid.Parse("10000000-0000-0000-0000-000000000002");
            var product3Id = Guid.Parse("10000000-0000-0000-0000-000000000003");
            var product4Id = Guid.Parse("10000000-0000-0000-0000-000000000004");
            var product5Id = Guid.Parse("10000000-0000-0000-0000-000000000005");

            var products = new[]
            {
                new Product
                {
                    Id = product1Id,
                    Name = "Cerveja Lager 600ml",
                    Description = "Cerveja clara tradicional",
                    Price = 9.99m,
                    Has10PercentDiscount = true,
                    Has20PercentDiscount = false,
                    Status = ProductStatus.Active,
                    CreatedAt = now.AddMinutes(30)
                },
                new Product
                {
                    Id = product2Id,
                    Name = "Guaraná Antarctica 2L",
                    Description = "Refrigerante brasileiro",
                    Price = 6.49m,
                    Has10PercentDiscount = false,
                    Has20PercentDiscount = true,
                    Status = ProductStatus.Active,
                    CreatedAt = now.AddMinutes(40)
                },
                new Product
                {
                    Id = product3Id,
                    Name = "Água Mineral 500ml",
                    Description = "Sem gás",
                    Price = 2.50m,
                    Has10PercentDiscount = false,
                    Has20PercentDiscount = false,
                    Status = ProductStatus.Active,
                    CreatedAt = now.AddMinutes(50)
                },
                new Product
                {
                    Id = product4Id,
                    Name = "Isotônico PowerUp 700ml",
                    Description = "Repositor energético",
                    Price = 7.89m,
                    Has10PercentDiscount = true,
                    Has20PercentDiscount = true,
                    Status = ProductStatus.Active,
                    CreatedAt = now.AddHours(1),
                },
                new Product
                {
                    Id = product5Id,
                    Name = "Suco Natural Laranja 1L",
                    Description = "Sem conservantes",
                    Price = 8.75m,
                    Has10PercentDiscount = false,
                    Has20PercentDiscount = false,
                    Status = ProductStatus.OutOfStock,
                    CreatedAt = now.AddHours(2),
                }
            };

            // ==== CARTS ====
            var cart1Id = Guid.Parse("20000000-0000-0000-0000-000000000001");
            var cart2Id = Guid.Parse("20000000-0000-0000-0000-000000000002");
            var cart3Id = Guid.Parse("20000000-0000-0000-0000-000000000003");

            var carts = new[]
            {
                new Cart
                {
                    Id = cart1Id,
                    UserId = clientId,
                    Date = now,
                    DiscountPercent = 10,
                    Status = CartStatus.Paid,
                    CreatedAt = now.AddHours(3),
                },
                new Cart
                {
                    Id = cart2Id,
                    UserId = clientId,
                    Date = now,
                    DiscountPercent = 0,
                    Status = CartStatus.Pending,
                    CreatedAt = now.AddHours(2)
                },
                new Cart
                {
                    Id = cart3Id,
                    UserId = sellerId,
                    Date = now,
                    DiscountPercent = 20,
                    Status = CartStatus.Shipped,
                    CreatedAt = now.AddHours(2)
                }
            };

            // ==== CART ITEMS ====
            var cartItems = new[]
            {
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart1Id,
                    ProductId = product1Id,
                    Quantity = 1,
                    UnitPrice = 9.99m,
                    DiscountPercent = 0
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart1Id,
                    ProductId = product2Id,
                    Quantity = 1,
                    UnitPrice = 6.49m,
                    DiscountPercent = 10
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart2Id,
                    ProductId = product3Id,
                    Quantity = 3,
                    UnitPrice = 2.50m,
                    DiscountPercent = 0
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart2Id,
                    ProductId = product4Id,
                    Quantity = 1,
                    UnitPrice = 7.89m,
                    DiscountPercent = 0
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart3Id,
                    ProductId = product1Id,
                    Quantity = 2,
                    UnitPrice = 9.99m,
                    DiscountPercent = 20
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart3Id,
                    ProductId = product2Id,
                    Quantity = 1,
                    UnitPrice = 6.49m,
                    DiscountPercent = 20
                }
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Cart>().HasData(carts);
            modelBuilder.Entity<CartItem>().HasData(cartItems);
        }
    }
}
