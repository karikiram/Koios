using Koios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Interfaces
{
	public interface IServiceTown
	{
		Task <TownDto> CreateTown(TownDto townDto);
		Task <List<TownDto>> GetTowns();
		Task <List<CountryDto>> GetCountries();
		Task<int?> DeleteTown(int? id);
		Task<int> TownCount();
		Task<TownDto> GetTown(int? id);
		Task<TownDto> EditTown(TownDto townDto);
	}
}
