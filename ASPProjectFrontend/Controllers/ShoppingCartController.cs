using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class ShoppingCartController(ApiServices api) : BaseController(api)
{
	// GET: ShoppingCartController
	public async Task<IActionResult> Index()
	{
		var shoppingCart = new ShoppingCart();
		var games = await api.GetAllGames();
		shoppingCart.Products.AddRange(games);
		ViewBag.ShoppingCart = shoppingCart;
		//UpdateShoppingCartCookie(shoppingCart);

		return View();
	}

	// GET: ShoppingCartController/Delete/5
	public ActionResult Delete(int id)
	{
		return View();
	}

	// POST: ShoppingCartController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(int id, IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
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
		SetShoppingCartInViewBag(shoppingCart);

		return RedirectToAction("Index");
	}
}
