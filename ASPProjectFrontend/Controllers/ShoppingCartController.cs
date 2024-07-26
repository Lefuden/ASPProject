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

	// Checkout Enbart inloggad, är man inte inloggad, hänvisa anvädnaren att logga in och returnera MEN! Tillåt anownymous
	// För då kan vi kolla HttpContext.User.Identity.IsAuthenticated
	// Om vi inte är inloggade, hänvisa användaren till login men se till att dem returnerar tillbaka hit
}
