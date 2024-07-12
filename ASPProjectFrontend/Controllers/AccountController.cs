using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class AccountController(ApiServices apiServices) : Controller
{
    private readonly ApiServices _api = apiServices;

    [HttpGet]
    public async Task<IActionResult> AddAddress()
    {
        return View(new Address());
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddress(Address address)
    {
        var user = HttpContext.User;
        var result = await _api.AddAddressToNewUser(address, user);
        if (result)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("AddAddress");
        }
    }

    public IActionResult Index()
    {
        return View();
    }
}
