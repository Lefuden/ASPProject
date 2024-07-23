using ASPProjectFrontend.Models;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
    public async Task<List<Game>> GetAllGames()
    {
        List<Game> games = new(){
        {new(){Id = 1, Name = "Example Game 1", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}},
        {new() {Id = 2, Name = "Example Game 2", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}},
        {new() {Id = 3, Name = "Example Game 3", ShortDescription = "This is a short description of the example game.", HeaderImage = "path-to-image.jpg", InitialPrice = 59, DiscountPercent = 20}}
      };
        return games;
    }
}
