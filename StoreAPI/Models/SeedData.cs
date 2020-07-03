using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreDBContext(serviceProvider.GetRequiredService<
                    DbContextOptions<StoreDBContext>>()))
            {
                // Look for any movies.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        Name = "The name of the firts product",
                        
                    },

                    new Product
                    {
                        Name = "Honey",
                    },

                    new Product
                    {
                        Name = "The pant",
                    },

                    new Product
                    {
                        Name = "A blouse",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
