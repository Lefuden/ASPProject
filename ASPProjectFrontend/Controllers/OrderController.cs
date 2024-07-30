using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class OrderController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
