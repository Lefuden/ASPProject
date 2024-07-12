using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class AuthenticationController(ApiServices apiServices) : Controller
{
    private readonly ApiServices _api = apiServices;

    [HttpGet]
    public IActionResult SignInWithGoogle()
    {
        var redirectUrl = Url.Action("GoogleResponse");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
    [HttpGet]
    public async Task<IActionResult> GoogleResponse()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (!authenticateResult.Succeeded || authenticateResult.Principal == null)
        {
            return BadRequest();
        }

        var idToken = authenticateResult.Properties.GetTokenValue("id_token");
        var (claims, authProperties, newUser) = await _api.GoogleAuth(idToken);
        if (claims == null || authProperties == null)
        {
            return BadRequest();
        }

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims, authProperties);

        if (newUser)
        {
            return RedirectToAction("AddAddress", "Account");
        }

        return RedirectToAction("Index", "Home");
    }
}
