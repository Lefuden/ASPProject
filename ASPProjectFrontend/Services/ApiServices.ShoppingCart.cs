using ASPProjectFrontend.Models;
using ASPProjectFrontend.Models.DTO;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
	public async Task<List<Game>> Checkout(CheckoutDto checkout)
	{
		var response = await _client.PostAsJsonAsync("Orders/Checkout", checkout);
		if (!response.IsSuccessStatusCode)
		{
			return [];
		}

		var jsonResponse = await response.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(jsonResponse))
		{
			return [];
		}

		var games = JsonConvert.DeserializeObject<List<Game>>(jsonResponse)!;
		return games;
	}
}