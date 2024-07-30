﻿using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjectFrontend.Controllers;
public class GameController(ApiServices api) : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult> Details(int id)
    {
        var game = await api.GetGameById(id);
        return View(game);
    }

    // If needed, Admin only Create Game


    // Admin only
    [HttpGet]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult> Edit(int id)
    {
        var game = await api.GetGameById(id);
        return View(game);
    }

    // Admin only
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Game game)
    {
        var result = await api.EditGame(game);
        if (result)
        {
            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            return View();
        }
    }
}
