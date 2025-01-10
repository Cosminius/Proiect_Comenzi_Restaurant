using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_Restaurantul_Meu.Models;

namespace Proiect_Medii_Restaurantul_Meu.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Am definit cheile compuse pentru ProductIngredient, si definim structura tabelara explicit
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi=> new {pi.ProductId, pi.IngredientId}); //Aici aveam o cheie primara formata din 2 chei straine
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            //Tabelul  category are valori predefinite 
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Aperitiv" },
                new Category { CategoryId = 2, Name = "Antree" },
                new Category { CategoryId = 3, Name = "Garnitura" },
                new Category { CategoryId = 4, Name = "Desert" },
                new Category { CategoryId = 5, Name = "Bautura Racoritoare" }
              
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Vita" },
                new Ingredient { IngredientId = 2, Name = "Pui" },
                new Ingredient { IngredientId = 3, Name = "Porc" },
                new Ingredient { IngredientId = 4, Name = "Somon" },
                new Ingredient { IngredientId = 5, Name = "Salata Verde" },
                new Ingredient { IngredientId = 7, Name = "Rosie" },
                new Ingredient { IngredientId = 8, Name = "Ardei Iute" },
                new Ingredient { IngredientId = 15, Name = "Ceapa" },
                new Ingredient { IngredientId =9, Name = "Usturoi" },
                new Ingredient { IngredientId = 10, Name = "Cartofi" },
                new Ingredient { IngredientId = 11, Name = "Orez" },
                new Ingredient { IngredientId = 12, Name = "Zahar" },
                new Ingredient { IngredientId = 13, Name = "Sirop de Cola" },
                new Ingredient { IngredientId = 14, Name = "Grasime de Porc" }


                );
            modelBuilder.Entity<Product>().HasData(
                new Product {
                    ProductId = 1,
                    Name = "Beef Tartar",
                    Description = "Vita de cea mai buna calitate",
                    Price = 50.50m,
                    Stock = 23,
                    CategoryId = 1
                },

                 new Product
                 {
                     ProductId = 2,
                     Name = "Somon cu sos Grecesc",
                     Description = "O experienta culinara mediteraneana la tine acasa",
                     Price = 80.50m,
                     Stock = 10,
                     CategoryId = 2
                 },

                 new Product
                 {
                     ProductId = 3,
                     Name = "Snitel Vienez",
                     Description = "Cel mai crocant snitel din Cluj",
                     Price = 25.00m,
                     Stock = 80,
                     CategoryId = 2
                 },
                 new Product
                 {
                     ProductId = 4,
                     Name = "Orez Indian",
                     Description = "Orez ca pe Valea Indului",
                     Price = 5.20m,
                     Stock = 200,
                     CategoryId = 3
                 },
                 new Product
                 {
                     ProductId = 5,
                     Name = "Creme Brule",
                     Description = "Cel mai bun desert",
                     Price = 15.00m,
                     Stock = 80,
                     CategoryId = 4
                 },
                  new Product
                   {
                       ProductId = 6,
                       Name = "Cartofi Prajiti in Grasime de vita",
                       Description = "O experienta americana",
                       Price = 15.00m,
                       Stock = 150,
                       CategoryId = 3
                   },
                   new Product
                    {
                        ProductId = 7,
                        Name = "Coca-Cola Zero",
                        Description = "Nu dai gres",
                        Price = 10.00m,
                        Stock = 500,
                        CategoryId = 5
                    },

                     new Product
                     {
                         ProductId = 8,
                         Name = "Tochitura de Porc",
                         Description = "Mai buna decat la bunica",
                         Price = 65.00m,
                         Stock = 30,
                         CategoryId = 2
                     });

            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 8 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 8 },
                new ProductIngredient { ProductId = 3, IngredientId = 2 },
                new ProductIngredient { ProductId = 3, IngredientId = 9 },
                new ProductIngredient { ProductId = 4, IngredientId = 11 },
                new ProductIngredient { ProductId = 5, IngredientId = 12 },
                new ProductIngredient { ProductId = 6, IngredientId = 10 },
                new ProductIngredient { ProductId = 7, IngredientId = 13 },
                new ProductIngredient { ProductId = 8, IngredientId = 3 },
                new ProductIngredient { ProductId = 8, IngredientId = 9 },
                new ProductIngredient { ProductId = 8, IngredientId = 14 });

        }
    }
}
