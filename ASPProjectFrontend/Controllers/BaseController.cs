using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Controllers;
public class BaseController(ApiServices api) : Controller
{

	protected void SetShoppingCartInViewBagFromCookie()
	{
		var shoppingCart = GetShoppingCartFromCookie();

		if (shoppingCart != null)
		{
			ViewBag.ShoppingCart = shoppingCart;
		}
	}
	protected void SetShoppingCartInViewBag(ShoppingCart shoppingCart)
	{
		if (shoppingCart != null)
		{
			ViewBag.ShoppingCart = shoppingCart;
		}
	}
	protected ShoppingCart GetShoppingCartFromCookie()
	{
		var shoppingCartJson = HttpContext.Request.Cookies["ShoppingCart"];

		if (string.IsNullOrEmpty(shoppingCartJson))
		{
			return new ShoppingCart();
		}

		var shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(shoppingCartJson);

		return shoppingCart;
	}
	protected void UpdateShoppingCartCookie(ShoppingCart shoppingCart)
	{
		var shoppingCartJson = JsonConvert.SerializeObject(shoppingCart);
		Response.Cookies.Append("ShoppingCart", shoppingCartJson, new CookieOptions
		{
			HttpOnly = true,
			Secure = true,
			Expires = DateTime.Now.AddDays(7)
		});

		SetShoppingCartInViewBag(shoppingCart);
	}
}