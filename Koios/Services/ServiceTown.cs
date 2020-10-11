using AutoMapper;
using Koios.Interfaces;
using Koios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Services
{
	public class ServiceTown : IServiceTown
	{
		private readonly MyContext _context;
		private readonly IMapper _mapper;
		public ServiceTown(MyContext myContext, IMapper mapper)
		{
			_context = myContext;
			_mapper = mapper;
		}
		public async Task<TownDto> CreateTown(TownDto townDto)
		{
				var town = new Town
				{
					TownName = townDto.TownName,
					PostalCode = townDto.PostalCode,
					CountryId = townDto.CountryId
				};
				 _context.Add(town);
				await _context.SaveChangesAsync();
				return townDto;
		}

		public async Task<int> TownCount()
		{
			var towns = await _context.Towns.ToListAsync();
			var townsDto = _mapper.Map<List<TownDto>>(towns);
			var townCount = townsDto.Count();
			return townCount;
		}

		public async Task<List<TownDto>> GetTowns()
		{
			var towns = await _context.Towns.Include(x => x.Countries).ToListAsync();
			var townsDto = _mapper.Map<List<TownDto>>(towns);
			return townsDto;
		}

		public async Task<List<CountryDto>> GetCountries()
		{
			var countries = await _context.Countries.ToListAsync();
			var countriesDto = _mapper.Map<List<CountryDto>>(countries);
			return countriesDto;
		}

		public async Task<int?> DeleteTown(int? id)
		{
			Town town = await _context.Towns.FindAsync(id);
			_context.Towns.Remove(town);
			await _context.SaveChangesAsync();
			return id;
		}

		public async Task<TownDto> GetTown(int? id)
		{
			var town = await _context.Towns.Where(x => x.TownId == id).FirstOrDefaultAsync();
			var townDto = _mapper.Map<TownDto>(town);
			return townDto;
		}

		public async Task<TownDto> EditTown(TownDto townDto)
		{
			var town = _mapper.Map<Town>(townDto);
			_context.Towns.Update(town);
			await _context.SaveChangesAsync();
			return townDto;
		}
	}
}
