using ASPProjectFrontend.Models;
using ASPProjectFrontend.Models.DTO;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

		int.TryParse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value, out int userId);
		var gameIds = games
			.AsEnumerable()
			.Select(g => g.Id)
			.ToList();

		var gamesCheckout = await api.Checkout(new CheckoutDto { UserId = userId, Games = gameIds });
		UpdateShoppingCartAfterCheckout();
		return View("OrderConfirmation", gamesCheckout);
	}

	[HttpGet]
	public IActionResult OrderConfirmation(List<Game> games)
	{
		return View(games);
	}
}
