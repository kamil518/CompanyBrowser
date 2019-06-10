using NIPApplication.Models;
using NIPApplication.Persistance;

namespace NIPApplication.Services
{
	public class QueryHistoryService : IQueryHistoryService
	{
		private readonly IDbContext _context;

		public QueryHistoryService(IDbContext context)
		{
			_context = context;
		}

		public void LogQuery(CompanySearchQuery queryLog)
		{
			_context.SearchQueries.Add(queryLog);
			_context.SaveChanges();
		}
	}
}