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
                if (context.Products.Any())
                {
                    logger.LogInformation("The database was already seeded");
                    return; // DB has been seeded
                }
                context.Products.AddRange(
                    new Product { Name = "Hammer", Price = 121.50m, Category = "Verktøy" },
                    new Product { Name = "Vinkelsliper", Price = 1520.00m, Category = "Verktøy" },
                    new Product { Name = "Volvo XC90", Price = 990000m, Category = " Kjøretøy" },
                    new Product { Name = "Volvo XC60", Price = 620000m, Category = "Kjøretøy" },
                    new Product { Name = "Brød", Price = 25.50m, Category = "Dagligvarer" }
                );
                context.SaveChanges();
                logger.LogInformation("Finished seeding the database.");
            }
        }
    }
}
