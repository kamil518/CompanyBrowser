using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NIPApplication.Services;

namespace NIPApplication.Controllers
{
	[Route("api/[controller]")]
	public class CompaniesController : Controller
	{
		private readonly ICompanyService _companyService;

		public CompaniesController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCompany(string key)
		{
			if (string.IsNullOrWhiteSpace(key)) return BadRequest();

			return Ok(await _companyService.GetCompany(key));
		}
	}
}