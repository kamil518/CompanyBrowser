using Microsoft.EntityFrameworkCore;
using NIPApplication.Models;

namespace NIPApplication.Persistance
{
	public interface IDbContext
	{
		 DbSet<Company> Companies { get; set; }
		 DbSet<CompanySearchQuery> SearchQueries { get; set; }
		 int SaveChanges();
	}
}