using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Controllers;

public class BaseController(ApiServices api) : Controller
{
    [AllowAnonymous]
    protected void SetShoppingCartInViewBagFromCookie()
    {
        var shoppingCart = GetShoppingCartFromCookie();

        if (shoppingCart != null)
        {
            ViewBag.ShoppingCart = shoppingCart;
        }
    }

    [AllowAnonymous]
    protected void SetShoppingCartInViewBag(ShoppingCart shoppingCart)
    {
        if (shoppingCart != null)
        {
            ViewBag.ShoppingCart = shoppingCart;
        }
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
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