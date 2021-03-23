using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesFirst.Data;
using System;
using System.Linq;

namespace RazorPagesFirst.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesFirstContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesFirstContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Zonja Bovari",
                        Author = "Gustav Flober",
                        ReleaseDate = DateTime.Parse("1990-4-12"),
                        Type = "Novel",
                        Price = 1400L
                    },

                    new Book
                    {
                        Title = "Anja",
                        Author = "Ahmet Prenci",
                        ReleaseDate = DateTime.Parse("2008-05-03"),
                        Type = "Roman",
                        Price = 1000L
                    }
                );
                context.SaveChanges();
            }
        }
    }
}