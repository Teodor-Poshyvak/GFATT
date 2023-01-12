using GFAT.Domain.Extensions;
using GFAT.Domain.ViewModels.Food;
using GFAT.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GFAT.Controllers;

public class FoodController : Controller
{
	private readonly IFoodService _foodService;

	public FoodController(IFoodService foodService)
	{
		_foodService = foodService;
	}

	[HttpGet]
	public IActionResult GetFoods()
	{
		var fooder = _foodService.GetFoods();
		if (fooder.StatusCode == Domain.Enum.StatusCode.OK)
		{
			return View(fooder.Data);
		}

		return View("Error", $"{fooder.Description}");
	}

	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(int id)
	{
		var fooder = await _foodService.DeleteFood(id);
		if (fooder.StatusCode == Domain.Enum.StatusCode.OK)
		{
			return RedirectToAction("GetFoods");
		}

		return View("Error", $"{fooder.Description}");
	}

	public IActionResult Compare() => PartialView();

	[HttpGet]
	public async Task<IActionResult> Save(int id)
	{
		if (id == 0)
			return PartialView();

		var fooder = await _foodService.GetFood(id);
		if (fooder.StatusCode == Domain.Enum.StatusCode.OK)
		{
			return PartialView(fooder.Data);
		}

		ModelState.AddModelError("", fooder.Description);
		return PartialView();
	}

	// string name, string description, decimal price, string CatagoryFood, IFormFile Avatar
	[HttpPost]
	public async Task<IActionResult> Save(FoodViewModel model)
	{
		ModelState.Remove("DateCreate");
		if (ModelState.IsValid)
		{
			if (model.Id == 0)
			{
				byte[] imageData;
				using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
				}
				await _foodService.Create(model, imageData);
			}
			else
			{
				await _foodService.Edit(model.Id, model);
			}
			return RedirectToAction("GetFoods");   
		}
		var errorMessage = ModelState.Values
			.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList().Join();
		return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
	}


	[HttpGet]
	public async Task<ActionResult> GetFood(int id, bool isJson)
	{
		var fooder = await _foodService.GetFood(id);
		if (isJson)
		{
			return Json(fooder.Data);
		}

		return PartialView("GetFood", fooder.Data);
	}

	[HttpPost]
	public async Task<IActionResult> GetFood(string term, int page = 1, int pageSize = 5)
	{
		var fooder = await _foodService.GetFood(term);
		return Json(fooder.Data);
	}

	[HttpPost]
	public JsonResult GetTypes()
	{
		var types = _foodService.GetTypes();
		return Json(types.Data);
	}
}
	
