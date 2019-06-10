using System.Collections.Generic;
using NIPApplication.Models;

namespace NIPApplication.Tests
{
	public static class TestCompanies
	{
		public static readonly Company Gsk = new Company
		{
			Id = 1,
			Name = "GSK Services SP z O O",
			City = "Poznan",
			Krs = "0000231231",
			Nip = "7792254227",
			Regon = "300040065",
			Street = "Grunwaldzka",
			StreetNumber = "189",
			PostCode = "60-322",
			NipCountryCode = "PL"
		};

		public static readonly Company Google = new Company
		{
			Id = 2,
			Name = "Google Poland SP z O O",
			City = "Warszawa",
			Krs = "0000240611",
			Nip = "5252344078",
			Regon = "140182840",
			Street = "Emilii Plater",
			StreetNumber = "53",
			PostCode = "00-113",
			NipCountryCode = "PL"
		};

		public static readonly Company Microsoft = new Company
		{
			Id = 3,
			Name = "Microsoft SP z O O",
			City = "Warszawa",
			Krs = "0000056838",
			Nip = "5270103391",
			Regon = "010016565",
			Street = "Aleje Jerozolimskie",
			StreetNumber = "195A",
			PostCode = "02-222",
			NipCountryCode = "PL"
		};

		public static readonly Company FakeCompany1 = new Company
		{
			Id = 4,
			Name = "Fake Comapny 1",
			City = "Radom",
			Krs = "2010056438",
			Nip = "5270103391",
			Regon = "010013665",
			Street = "Marii Konopnickiej",
			StreetNumber = "12",
			PostCode = "26-601",
			NipCountryCode = "PL"
		};

		public static readonly Company FakeCompany2 = new Company
		{
			Id = 5,
			Name = "Fake Company 2",
			City = "Gdańsk",
			Krs = "0000056838",
			Nip = "2010056438",
			Regon = "010016565",
			Street = "Bydgoska",
			StreetNumber = "77",
			PostCode = "80-007",
			NipCountryCode = "PL"
		};

		public static readonly Company FakeCompany3 = new Company
		{
			Id = 5,
			Name = "Fake Company 3",
			City = "Pruszkow",
			Krs = "0000056838",
			Nip = "5542843430",
			Regon = "010016565",
			Street = "Warszawska",
			StreetNumber = "15",
			PostCode = "80-007",
			NipCountryCode = "DE"
		};

		public static List<Company> GetTestCompanies()
		{
			return new List<Company>
			{
				Gsk,
				Google,
				Microsoft,
				FakeCompany1,
				FakeCompany2,
				FakeCompany3
			};
		}
	}
}