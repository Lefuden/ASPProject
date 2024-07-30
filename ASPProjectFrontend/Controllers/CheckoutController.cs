using ASPProjectFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class CheckoutController : Controller
{
	public IActionResult PlacedOrder(List<Game> games)
	{
		return View(games);
	}
}
