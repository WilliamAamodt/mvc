using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using mvc.Models.Entites;

namespace mvc.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider app)
        {
            using (var context = new ApplicationDbContext(
                app.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Get a logger
                var logger = app.GetRequiredService<ILogger<Seed>>();
                // Make sure the database is created
                context.Database.EnsureCreated();
                // Look for any products.
                //if (context.Categories.Any())
                //{
                //    logger.LogInformation("The database was already seeded");
                //    return; // DB has been seeded
                //}
                //context.Categories.AddRange(
                //    new Category{Name = "Bil" ,Description = "Forskjellige biler"},
                //    new Category {Name = "Matvarer", Description = "Forskjellige matvarer"},
                //    new Category{Name = "Verktøy", Description = "Forskjellige verktøy"});
                //if (context.Manufacturers.Any())
                //{
                //    logger.LogInformation("The database was already seeded");
                //    return; // DB has been seeded
                //}
                //context.Manufacturers.AddRange(
                //    new Manufacturer{Name = "Volvo", Address = "Langstranda 2",Description = "Bilprodusent"},
                //    new Manufacturer{Name = "Gilde",Address = "Slakterveien 14", Description = "Slakter og matvare produsent"},
                //    new Manufacturer{Name = "Bosch",Address = "Potsdammer Platz 1", Description = "Tysk verktøy produsent"});

                //Kommentert ut, for å ungå duplikasjoner av Kategori og Manufacturers
                
                if (context.Products.Any())
                {
                    logger.LogInformation("The database was already seeded");
                    return; // DB has been seeded
                }
                context.Products.AddRange(
                    new Product { Name = "Hammer", Price = 121.50m, CategoryId = 13, ManufacturerId = 10 },
                    new Product { Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 13, ManufacturerId = 10 },
                    new Product { Name = "Volvo XC90", Price = 990000m, CategoryId = 11, ManufacturerId = 8 },
                    new Product { Name = "Volvo XC60", Price = 620000m, CategoryId = 11, ManufacturerId = 8 },
                    new Product { Name = "Brød", Price = 25.50m, CategoryId = 12, ManufacturerId = 9 }

                );
                context.SaveChanges();
                logger.LogInformation("Finished seeding the database.");
            }
        }
    }
}
