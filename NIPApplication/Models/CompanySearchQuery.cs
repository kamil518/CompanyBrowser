using System;
using System.ComponentModel.DataAnnotations;
using NIPApplication.Enums;

namespace NIPApplication.Models
{
	public class CompanySearchQuery
	{
		public CompanySearchQuery(string query)
		{
			Timestamp = DateTime.Now;
			Query = query;
		}

		public int Id { get; set; }

		public DateTime Timestamp { get; private set; }

		public string Query { get; private set; }

		public QueryType QueryType { get; set; }
	}
}