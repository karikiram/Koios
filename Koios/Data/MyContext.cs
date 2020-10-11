using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koios.Models;

namespace Koios.Models
{
	public class MyContext : DbContext
	{
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MyContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//odlučio sam se na ovakav slučaj zato što vjerojatno ne postoji država s istim poštanskim i gradom. Možda je bio neki bolji odabir
			modelBuilder.Entity<Town>()
			.HasIndex(x => new {x.TownName, x.PostalCode }).IsUnique();
		}
	}
}
