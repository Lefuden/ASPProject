using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPProjectFrontend.Controllers;
public class HomeController(ApiServices api, ILogger<HomeController> logger) : BaseController(api)
{
    private readonly ILogger<HomeController> _logger = logger;

    public async Task<IActionResult> Index()
    {
        SetShoppingCartInViewBagFromCookie();
        return View(await api.GetAllGames());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddToCart(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var shoppingCart = GetShoppingCartFromCookie();
        var game = await api.GetGameById(id);

        shoppingCart.Products.Add(game);

        UpdateShoppingCartCookie(shoppingCart);

        return RedirectToAction("Index");
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RemoveFromCart(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var shoppingCart = GetShoppingCartFromCookie();
        shoppingCart.Products = shoppingCart.Products.Where(game => game.Id != id).ToList();

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
