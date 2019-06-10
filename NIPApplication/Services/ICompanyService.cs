using System.Threading.Tasks;
using NIPApplication.Models;

namespace NIPApplication.Services
{
	public interface ICompanyService
	{
		Task<Company> GetCompany(string key);
	}
}