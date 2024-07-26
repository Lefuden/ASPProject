using ASPProjectFrontend.Models;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
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

    public async Task<bool> EditOrder(Order editOrder)
    {
        var response = await _client.PostAsJsonAsync("Orders/Edit", editOrder);
        return response.IsSuccessStatusCode;
    }
}
