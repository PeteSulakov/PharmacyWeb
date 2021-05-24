using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Configuration;

namespace PharmacyWeb.Models
{
	public class PharmacyContext : IdentityDbContext<User>
	{
		public PharmacyContext(DbContextOptions<PharmacyContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new RoleConfiguration());
		}

		public DbSet<Medicine> Medicines { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ActiveSubstance> ActiveSubstances { get; set; }
		public DbSet<Producer> Producers { get; set; }
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<MedicineForm> MedicineForms { get; set; }
	}
}
