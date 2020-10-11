using Koios.Interfaces;
using Koios.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koios.Dependencies
{
	public static class ServicesDependency
	{
		public static void AddServiceDependency(this IServiceCollection services)
		{
			services.AddTransient<IServiceTown, ServiceTown>();
		}
	}
}
