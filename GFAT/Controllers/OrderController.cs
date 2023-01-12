using GFAT.Domain.ViewModels.Order;
using GFAT.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFAT.Controllers;

public class OrderController : Controller
{
    // GET
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult CreateOrder(long id)
    {
        var orderModel = new CreateOrderViewModel()
        {
            FoodId = id,
            Login = User.Identity.Name,
            Quantity = 0
        };
        return View(orderModel);
    }
        
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _orderService.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Json(new { description = response.Description });
            }
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
        
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _orderService.Delete(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("Detail", "Basket");
        }
        return View("Error", $"{response.Description}");
    }

}