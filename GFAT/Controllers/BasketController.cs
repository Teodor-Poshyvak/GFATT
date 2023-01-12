﻿using GFAT.Domain.ViewModels.Order;
using GFAT.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFAT.Controllers;

public class BasketController : Controller
{
    // GET
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> Detail()
    {
        var response = await _basketService.GetItems(User.Identity.Name);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data.ToList());
        }
        return RedirectToAction("Index", "Home");
    }
        
    [HttpGet]
    public async Task<IActionResult> GetItem(long id)
    {
        var response = await _basketService.GetItem(User.Identity.Name, id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return PartialView(response.Data);
        }
        
        return RedirectToAction("Index", "Home");
    }


}