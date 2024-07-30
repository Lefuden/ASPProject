using ASPProjectFrontend.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
    [Authorize(Roles = "Admin")]
    public async Task<List<Order>> GetAllOrders()
    {
        var response = await _client.GetAsync("Orders");
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
        return orders;
    }

    [Authorize(Roles = "User")]
    public async Task<List<Order>> GetAllUserOrders(int? userId)
    {
        if (userId == null)
        {
            return [];
        }

        var response = await _client.GetAsync($"Orders/User/{userId}");
        Console.WriteLine(response);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
        return orders;
    }

    [Authorize(Roles = "Admin,User")]
    public async Task<Order> GetSpecificOrder(int? orderId)
    {
        if (orderId == null)
        {
            return default;
        }

        var response = await _client.GetAsync($"Orders/{orderId}");
        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var order = JsonConvert.DeserializeObject<Order>(jsonResponse);
        return order;
    }
}
