using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesFirst.Models;

namespace RazorPagesFirst.Data
{
    public class RazorPagesFirstContext : DbContext
    {
        public RazorPagesFirstContext (DbContextOptions<RazorPagesFirstContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesFirst.Models.Book> Book { get; set; }
        public object Books { get; internal set; }
    }
}
