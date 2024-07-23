using ASPProjectFrontend.Models;
using Newtonsoft.Json;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
    public async Task<List<Game>> GetAllGames()
    {
        var response = await _client.GetAsync("Games");
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var games = JsonConvert.DeserializeObject<List<Game>>(jsonResponse);
        return games!;
    }

    public async Task<bool> EditGame(Game updateGame)
    {
        var response = await _client.PostAsJsonAsync("Games/Edit", updateGame);
        return response.IsSuccessStatusCode;
    }
}
