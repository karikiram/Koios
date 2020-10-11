using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Koios.Models;
using AutoMapper;
using Koios.Interfaces;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Koios.Controllers
{
	public class TownsController : Controller
	{
		private readonly IServiceTown _serviceTown;

		public TownsController(IServiceTown serviceTown)
		{
			_serviceTown = serviceTown;
		}


		[HttpGet("Towns/CreateTown")]
		public async Task <IActionResult> CreateTown()
		{
			var countriesList = await _serviceTown.GetCountries();
			ViewBag.TotalCountries = countriesList;
			TownDto townDto = new TownDto();
			return PartialView("_TownModelPartial", townDto);
		}

		[HttpPost("Towns/CreateTown")]
		public async Task<IActionResult> CreateTown(TownDto townDto)
		{
			if (!ModelState.IsValid)
			{
				return PartialView("_TownModelPartial", townDto);
			}
			else { 
				try
				{
					await _serviceTown.CreateTown(townDto);
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					return PartialView("_TownModelPartial", townDto);
				}
			}
		}

		[HttpGet("Towns/Index")]
		public async Task <IActionResult> Index()
		{
			try
			{
				var data = await _serviceTown.GetTowns();
				var townList = await _serviceTown.TownCount();
				ViewBag.TotalTowns = townList;
				return View(data);
			}

			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost("Towns/DeleteTown")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteTown(int? id)
		{
			try
			{
				if (id != null)
				{
					await _serviceTown.DeleteTown(id);
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("Towns/EditTown/{id}")]
		public async Task<IActionResult> EditTown(int id)
		{
			var countriesList = await _serviceTown.GetCountries();
			ViewBag.TotalCountries = countriesList;
			var townDto = await _serviceTown.GetTown(id);
			return PartialView("_EditTownModelPartial", townDto);
		}

		[HttpPost("Towns/EditTown")]
		public async Task<IActionResult> EditTown(TownDto townDto)
		{
			if (!ModelState.IsValid)
			{
				//ModelState.AddModelError("", "");
				return View(townDto);
			}
			else
			{
				try
				{
					await _serviceTown.EditTown(townDto);
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					return BadRequest(ex);
				}
			}
		}
	}
}
