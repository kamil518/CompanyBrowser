using NIPApplication.Models;

namespace NIPApplication.Services
{
	public interface IQueryHistoryService
	{
		void LogQuery(CompanySearchQuery queryLog);
	}
}