using Microsoft.EntityFrameworkCore;
using NIPApplication.Models;

namespace NIPApplication.Persistance
{
	public class ApplicationDbContext : DbContext, IDbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<CompanySearchQuery> SearchQueries { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Map table names
			modelBuilder.Entity<Company>().ToTable("Companies");
			modelBuilder.Entity<Company>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name);
				entity.HasIndex(e => e.Nip).IsUnique();
				entity.Property(e => e.NipCountryCode).HasDefaultValue("PL");
				entity.HasIndex(e => e.Regon).IsUnique();
				entity.HasIndex(e => e.Krs).IsUnique();
				entity.Property(e => e.Street);
				entity.Property(e => e.StreetNumber);
				entity.Property(e => e.PostCode);
				entity.Property(e => e.City);
			});

			modelBuilder.Entity<CompanySearchQuery>().ToTable("CompanySearchQueries");
			modelBuilder.Entity<CompanySearchQuery>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.HasIndex(e => e.Timestamp).IsUnique();
				entity.Property(e => e.Query);
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}