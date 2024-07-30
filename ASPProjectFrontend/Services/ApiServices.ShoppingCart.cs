using ASPProjectFrontend.Models;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
	public async Task<List<Game>> Checkout(List<Game> games)
	{
		var gameIds = games
			.AsEnumerable()
			.Select(g => g.Id)
			.ToList();

		var response = await _client.PostAsJsonAsync("Orders/Checkout", gameIds);
		if (!response.IsSuccessStatusCode)
		{
			return [];
		}

		var jsonResponse = await response.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(jsonResponse))
		{
			return [];
		}

		games = JsonConvert.DeserializeObject<List<Game>>(jsonResponse)!;
		return games;
	}
}