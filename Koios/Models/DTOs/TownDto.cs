using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Models
{
	public class TownDto
	{
		public int TownId { get; set; }
		public string TownName { get; set; }
		// Ne znam koliko koja država ima znakova, pa sam limitirao na 10
		public string PostalCode { get; set; }
		public int CountryId { get; set; }
		public Country Countries { get; set; }
	}
}
