using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PharmacyWeb.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData
				 (
				new IdentityRole
				{
					Id = "2b36bb0d-2d46-4875-817c-00f03fa7f79e",
					Name = "User",
					NormalizedName = "USER"
				},
				new IdentityRole
				{
					Id = "b6eeeeb7-76b0-4980-86f4-19e43538ccae",
					Name = "Admin",
					NormalizedName = "ADMIN"
				}
				);
		}
	}
}
