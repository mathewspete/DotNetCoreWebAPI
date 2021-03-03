using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Data
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext (DbContextOptions<WebAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreWebAPI.Models.Customer> Customer { get; set; }


    protected override void OnModelCreating(ModelBuilder builder) {
      // create an index for the table?
      builder.Entity<Customer>(e => {
        e.HasIndex(c => c.Code).IsUnique(true); //config/get idx for customers to use for code column. each Unique
      });
    }



  }
}
