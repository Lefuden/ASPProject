using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class GameController(ApiServices api) : Controller
{
    [AllowAnonymous]
    public ActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
        return View();
    }

    // If needed, Admin only Create Game


    // Admin only
    public ActionResult Edit(int id)
    {
        return View();
    }

    // Admin only
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Game updateGame)
    {
        var result = await api.EditGame(updateGame);
        if (result)
        {
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    // Admin only
    public ActionResult Delete(int id)
    {
        return View();
    }

    // Admin only
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
}
