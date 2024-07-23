using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class ShoppingCartController(ApiServices api) : BaseController(api)
{
    // GET: ShoppingCartController
    public ActionResult Index()
    {
        SetShoppingCartInViewBagFromCookie();
        return View();
    }

    // GET: ShoppingCartController/Details/5
    public ActionResult Details(int id)
    {
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
}
