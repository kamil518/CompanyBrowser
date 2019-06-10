using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NIPApplication.Controllers;
using NIPApplication.Models;
using NIPApplication.Services;
using NUnit.Framework;

namespace NIPApplication.Tests.Controllers
{
	[TestFixture]
	public class CompaniesControllerTests
	{
		private CompaniesController _companiesController;

		[SetUp]
		public void SetUp()
		{
			var companyServiceMock = new Mock<ICompanyService>();


			companyServiceMock.Setup(x => x.GetCompany(TestCompanies.Gsk.Nip)).Returns(Task.FromResult(TestCompanies.Gsk));
			companyServiceMock.Setup(x => x.GetCompany(TestCompanies.Google.Nip)).Returns(Task.FromResult(TestCompanies.Google));

			_companiesController = new CompaniesController(companyServiceMock.Object);
		}

		#region Tests

		[Test]
		public void GetCompany_QueryByNip_OkWithGsk()
		{
			var response = _companiesController.GetCompany(TestCompanies.Gsk.Nip).Result as OkObjectResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 200);

			var responseValue = response.Value as Company;

			Assert.NotNull(responseValue);
			Assert.AreEqual(responseValue.Id, TestCompanies.Gsk.Id);
		}

		[Test]
		public void GetCompany_QueryByNip_OkWithGoogle()
		{
			var response = _companiesController.GetCompany(TestCompanies.Google.Nip).Result as OkObjectResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 200);

			var responseValue = response.Value as Company;

			Assert.NotNull(responseValue);
			Assert.AreEqual(responseValue.Id, TestCompanies.Google.Id);
		}

		[Test]
		public void GetCompany_QueryByNip_OkWithNull()
		{
			var nonExistingNip = "325655635";
			var response = _companiesController.GetCompany(nonExistingNip).Result as OkObjectResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 200);

			Assert.IsNull(response.Value);
		}

		[Test]
		public void GetCompany_QueryByNipWithEmptyString_BadRequest()
		{
			var response = _companiesController.GetCompany(string.Empty).Result as BadRequestResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 400);
		}

		[Test]
		public void GetCompany_QueryByNipWithNull_BadRequest()
		{
			var response = _companiesController.GetCompany(null).Result as BadRequestResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 400);
		}

		[Test]
		public void GetCompany_QueryByNipWithWhiteSpaces_BadRequest()
		{
			var whiteSpaces = "    ";
			var response = _companiesController.GetCompany(whiteSpaces).Result as BadRequestResult;

			Assert.NotNull(response);
			Assert.AreEqual(response.StatusCode, 400);
		}

		#endregion
	}
}