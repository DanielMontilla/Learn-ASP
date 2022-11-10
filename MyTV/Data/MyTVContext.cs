using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTV.Models;

namespace MyTV.Data
{
    public class MyTVContext : DbContext
    {
        public MyTVContext (DbContextOptions<MyTVContext> options)
            : base(options)
        {
        }

        public DbSet<MyTV.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MyTV.Models.Show> Show { get; set; }
    }
}
