using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class GameController(ApiServices apiServices) : Controller
{
    private readonly ApiServices _api = apiServices;
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
    public ActionResult Edit(int id, IFormCollection collection)
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
