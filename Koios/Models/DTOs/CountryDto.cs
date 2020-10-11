using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Models
{
	public class CountryDto
	{
		public int CountryId { get; set; }
		public string CountryName { get; set; }
		public ICollection<TownDto> Towns { get; set; }
	}
}
