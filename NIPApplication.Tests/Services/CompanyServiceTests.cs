using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NIPApplication.Models;
using NIPApplication.Persistance;
using NIPApplication.Services;
using NUnit.Framework;

namespace NIPApplication.Tests.Services
{
	[TestFixture]
	public class CompanyServiceTests
	{
		private CompanyService _companyService;
		

		[SetUp]
		public void SetUp()
		{
			var companiesMock = CreateDbSetMock(TestCompanies.GetTestCompanies());
			var searchQueriesMock = CreateDbSetMock(new List<CompanySearchQuery>());

			var applicationContextMock = new Mock<IDbContext>();
			var queryHistoryServiceMock = new Mock<IQueryHistoryService>();

			applicationContextMock.Setup(x => x.Companies).Returns(companiesMock.Object);
			applicationContextMock.Setup(x => x.SearchQueries).Returns(searchQueriesMock.Object);

			_companyService = new CompanyService(applicationContextMock.Object, queryHistoryServiceMock.Object);
		}

		#region KRS

		[Test]
		public void GetCompany_QueryByKrs_RecordFound()
		{
			const string gskKrs = "0000231231";
			var company = _companyService.GetCompany(gskKrs).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.Gsk.Id);
		}

		[Test]
		public void GetCompany_QueryByKrs_RecordNotFound()
		{
			const string nonExistingKrs = "0000112331";
			var company = _companyService.GetCompany(nonExistingKrs).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByKrsWithCountry_RecordNotFound()
		{
			const string krsWithCountryCode = "PL0000232331";
			var company = _companyService.GetCompany(krsWithCountryCode).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByKrsWithDashes_RecordNotFound()
		{
			const string krsWithDashes = "000-023-23-31";
			var company = _companyService.GetCompany(krsWithDashes).Result;

			Assert.Null(company);
		}

		#endregion

		#region NIP

		[Test]
		public void GetCompany_QueryByNip_RecordFound()
		{
			const string googleNip = "5252344078";
			var company = _companyService.GetCompany(googleNip).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.Google.Id);
		}

		[Test]
		public void GetCompany_QueryByNipWithDashes_RecordFound()
		{
			const string googleNipWithDashes = "525-234-40-78";
			var company = _companyService.GetCompany(googleNipWithDashes).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.Google.Id);
		}

		[Test]
		public void GetCompany_QueryByNipWithDashes_RecordNotFound()
		{
			const string nonExistingNipWithDashes = "525-000-40-78";
			var company = _companyService.GetCompany(nonExistingNipWithDashes).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByNipWithCountryCode_RecordFound()
		{
			const string googleNipWithCountryCode = "PL5252344078";
			var company = _companyService.GetCompany(googleNipWithCountryCode).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.Google.Id);
		}

		[Test]
		public void GetCompany_QueryByNipWithCountryCode2_RecordFound()
		{
			const string fakeCompany3NipWithCountryCode = "DE5542843430";
			var company = _companyService.GetCompany(fakeCompany3NipWithCountryCode).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.FakeCompany3.Id);
		}

		[Test]
		public void GetCompany_QueryByNipWithCountryCodeAndDashes_RecordNotFound()
		{
			const string googleNipWithCountryCodeAndDashes = "PL525-23-44-078";
			var company = _companyService.GetCompany(googleNipWithCountryCodeAndDashes).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByNipWrongCountryCodeFormat_RecordNotFound()
		{
			const string nonExistingNipWithCountryCode = "DE5252344078";
			var company = _companyService.GetCompany(nonExistingNipWithCountryCode).Result;

			Assert.Null(company);
		}

		#endregion

		#region REGON

		[Test]
		public void GetCompany_QueryByRegon_RecordFound()
		{
			const string microsoftRegon = "010016565";
			var company = _companyService.GetCompany(microsoftRegon).Result;

			Assert.NotNull(company);
			Assert.AreEqual(company.Id, TestCompanies.Microsoft.Id);
		}

		[Test]
		public void GetCompany_QueryByRegonWithDashes_RecordNotFound()
		{
			const string microsoftRegonWithDashes = "010-0165-65";
			var company = _companyService.GetCompany(microsoftRegonWithDashes).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByRegonWithCountryCode_RecordNotFound()
		{
			const string microsoftRegonWithCountryCode = "PL010016565";
			var company = _companyService.GetCompany(microsoftRegonWithCountryCode).Result;

			Assert.Null(company);
		}

		[Test]
		public void GetCompany_QueryByRegon_RecordNotFound()
		{
			const string nonExistingRegon = "010034565";
			var company = _companyService.GetCompany(nonExistingRegon).Result;

			Assert.Null(company);
		}

		#endregion

		#region MultipleRecords

		[Test]
		public void GetCompany_QueryByKrsWhenAnotherCompanyHasTheSameNip_WrongRecordFound()
		{
			const string fakeCompany1Regon = "2010056438";
			var company = _companyService.GetCompany(fakeCompany1Regon).Result;

			Assert.NotNull(company);
			Assert.AreNotEqual(company.Id, TestCompanies.FakeCompany1.Id);
			Assert.AreEqual(company.Id, TestCompanies.FakeCompany2.Id);
		}

		#endregion

		private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
		{
			var elementsAsQueryable = elements.AsQueryable();
			var dbSetMock = new Mock<DbSet<T>>();
			
			dbSetMock.As<IAsyncEnumerable<T>>()
				.Setup(m => m.GetEnumerator())
				.Returns(new TestAsyncEnumerator<T>(elementsAsQueryable.GetEnumerator()));

			dbSetMock.As<IQueryable<T>>()
				.Setup(m => m.Provider)
				.Returns(new TestAsyncQueryProvider<T>(elementsAsQueryable.Provider));

			dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

			return dbSetMock;
		}
	}
}