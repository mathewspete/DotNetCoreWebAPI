using DotNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DotNetCoreWebAPI.Data {
	public class WebAppDbContext : DbContext {
		public WebAppDbContext(DbContextOptions<WebAppDbContext> options)
				: base(options) {
		}

		public DbSet<Customer> Customer { get; set; }
		public DbSet<Item> Item { get; set; }
		public DbSet<Orderline> Orderline { get; set; }
		public DbSet<Order> Orders { get; set; }


		protected override void OnModelCreating(ModelBuilder builder) {
			// create an index for the table?
			builder.Entity<Customer>(e => {
				e.HasIndex(c => c.Code).IsUnique(true); //config/get idx for customers to use for code column. each Unique
			});
		}


	}
}
