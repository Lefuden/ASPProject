using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPProjectFrontend.Controllers;

public class HomeController(ApiServices api) : BaseController(api)
{
    public async Task<IActionResult> Index()
    {
        SetShoppingCartInViewBagFromCookie();
        return View(await api.GetAllGames());
    }
    [HttpPost]
    public IActionResult AddToCart(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var shoppingCart = GetShoppingCartFromCookie();

        shoppingCart.Products.Add((int)id);

        UpdateShoppingCartCookie(shoppingCart);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var shoppingCart = GetShoppingCartFromCookie();
        shoppingCart.Products = shoppingCart.Products.Where(productId => productId != id).ToList();

        UpdateShoppingCartCookie(shoppingCart);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
