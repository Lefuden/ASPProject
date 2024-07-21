using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPProjectFrontend.Controllers;
public class HomeController(ApiServices apiServices, ILogger<HomeController> logger) : Controller
{
  private readonly ApiServices _api = apiServices;
  private readonly ILogger<HomeController> _logger = logger;

  public IActionResult Index()
  {
    List<Game> games = new(){
        {new(){Id = 1, Name = "Example Game 1", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}},
        {new() {Id = 2, Name = "Example Game 2", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}},
        {new() {Id = 3, Name = "Example Game 3", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}}
      };
    return View(games);
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
