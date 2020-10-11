using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Koios.Models.Side_Classes
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Town, TownDto>();
			CreateMap<Country, CountryDto>();
			CreateMap<TownDto, Town>();
			CreateMap<CountryDto, Country>();
		}
	}
}
