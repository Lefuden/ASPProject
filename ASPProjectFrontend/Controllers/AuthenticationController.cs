using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class AuthenticationController(ApiServices api) : Controller
{
    [AllowAnonymous]
    [HttpGet]
    //sköter inloggning och verifiering
    public IActionResult SignInWithGoogle(bool atCheckout = false)
    {
        var redirectUrl = Url.Action("GoogleResponse");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
    [HttpGet]
    public async Task<IActionResult> GoogleResponse(bool atCheckout = false)
    {
        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (!authenticateResult.Succeeded || authenticateResult.Principal == null)
        {
            return BadRequest();
        }

        //hämtar google id token, skickar till backend för att verifiera
        //korrekt användare
        var idToken = authenticateResult.Properties.GetTokenValue("id_token");
        var (claims, authProperties, newUser) = await api.GoogleAuth(idToken);
        if (claims == null || authProperties == null)
        {
            return BadRequest();
        }

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims, authProperties);

        if (newUser)
        {
            return RedirectToAction("AddAddress", "Account");
        }
        if (atCheckout)
        {
            return RedirectToAction("Index", "ShoppingCart");
        }
        return RedirectToAction("Index", "Home");
    }
}
