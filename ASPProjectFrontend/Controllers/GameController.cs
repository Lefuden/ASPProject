using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class GameController(ApiServices api) : Controller
{
    // GET: GameController
    public ActionResult Index()
    {
        return View();
    }

    // GET: GameController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: GameController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: GameController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: GameController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: GameController/Edit/5
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

    // GET: GameController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: GameController/Delete/5
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
