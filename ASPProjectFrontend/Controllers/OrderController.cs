using ASPProjectFrontend.Models;
using ASPProjectFrontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASPProjectFrontend.Controllers;
public class OrderController(ApiServices api) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllOrders()
    {
        List<Order> orders = await api.GetAllOrders();
        return View(orders);
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetUserOrders()
    {
        var userId = int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
        List<Order> orders = await api.GetAllUserOrders(userId);
        return View(orders);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetSpecificOrder(int orderId)
    {
        var order = await api.GetSpecificOrder(orderId);
        return View(order);
    }

}
