using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Models
{
	public class Town
	{
		[Key]
		public int TownId { get; set; }
		[Required(ErrorMessage = "Ime grada je obavezno!")]
		[MaxLength(80)]
		[DataType(DataType.Text)]
		public string TownName { get; set; }
		[Required(ErrorMessage = "Poštanski broj je obavezan!")]
		[MaxLength(10)]
		// Ne znam koliko koja država ima znakova, pa sam limitirao na 10
		public string PostalCode { get; set; }
		[Required(ErrorMessage = "Odabir grada je obavezan!")]
		public int CountryId { get; set; }
		public Country Countries { get; set; }

	}
}
