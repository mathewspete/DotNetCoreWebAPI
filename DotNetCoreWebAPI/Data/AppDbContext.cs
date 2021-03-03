using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreWebAPI.Models.Customer> Customer { get; set; }
    }
}
