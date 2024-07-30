using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class ShoppingCartController(ApiServices api) : BaseController(api)
{
	[AllowAnonymous]
	public async Task<IActionResult> Index()
	{
		var shoppingCart = GetShoppingCartFromCookie();
		var games = await api.GetGamesFromIds(shoppingCart.Products);

		return View(games);
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
		shoppingCart.Products = shoppingCart.Products.Where(productId => productId != id).ToList();

		UpdateShoppingCartCookie(shoppingCart);

		return RedirectToAction("Index");
	}

	//[Authorize(Roles = "User")]
	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Checkout(List<Game> games)
	{
		if (!User.IsInRole("User"))
		{
			return RedirectToAction("SignInWithGoogle", "Authentication", true);
		}

		if (games.Count == 0)
		{
			return NotFound();
		}

		var gamesCheckout = await api.Checkout(games);
		return View("OrderConfirmation", gamesCheckout);
	}

	[HttpGet]
	public IActionResult OrderConfirmation(List<Game> games)
	{
		return View(games);
	}
}
