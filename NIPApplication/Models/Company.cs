using System.ComponentModel.DataAnnotations;

namespace NIPApplication.Models
{
	public class Company
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Nip { get; set; }

		public string NipCountryCode { get; set; }

		public string Regon { get; set; }
		public string Krs { get; set; }

		public string Street { get; set; }

		public string StreetNumber { get; set; }

		public string PostCode { get; set; }

		public string City { get; set; }
	}
}