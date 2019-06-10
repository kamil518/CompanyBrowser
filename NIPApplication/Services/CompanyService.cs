using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIPApplication.Enums;
using NIPApplication.Models;
using NIPApplication.Persistance;

namespace NIPApplication.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IDbContext _context;
		private readonly IQueryHistoryService _queryHistoryService;
		private readonly Regex _nipWithCountryCodeRegex = new Regex("^[A-Za-z]{2}[0-9]{10}$");

		public CompanyService(IDbContext context, IQueryHistoryService queryHistoryService)
		{
			_context = context;
			_queryHistoryService = queryHistoryService;
		}

		public async Task<Company> GetCompany(string key)
		{
			var queryLog = new CompanySearchQuery(key);

			Company result;

			if (_nipWithCountryCodeRegex.IsMatch(key))
			{
				result = await GetCompanyByNipWithCountryCode(key);
				queryLog.QueryType = QueryType.Nip;
			}
			else
			{
				result = await GetCompanyByKey(key);

				if (result?.Nip == key) queryLog.QueryType = QueryType.Nip;
				else if (result?.Krs == key) queryLog.QueryType = QueryType.Krs;
				else if (result?.Regon == key) queryLog.QueryType = QueryType.Regon;
				else queryLog.QueryType = QueryType.Undefined;
			}

			_queryHistoryService.LogQuery(queryLog);

			return result;
		}

		private async Task<Company> GetCompanyByKey(string key)
		{
			var nip = Regex.Replace(key, "-", string.Empty);

			var companies = await _context.Companies.Where
				(c => c.Nip == nip || c.Regon == key || c.Krs == key).ToListAsync();

			if (companies.Count > 1)
			{
				return companies.FirstOrDefault(c => c.Nip == nip) ??
				       companies.FirstOrDefault(c => c.Regon == key) ??
				       companies.FirstOrDefault(c => c.Krs == key);
			}

			return companies.FirstOrDefault();
		}

		private async Task<Company> GetCompanyByNipWithCountryCode(string nip)
		{
			return await _context.Companies.FirstOrDefaultAsync(c =>
				c.Nip == nip.Substring(2) && c.NipCountryCode == nip.Substring(0, 2));
		}
	}
}