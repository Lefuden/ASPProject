using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;

namespace ASPProjectBackend.Helpers;

public static class DtoConverter
{
    public static GameDto GameToDto(Game game) => new()
    {
        Id = game.Id,
        Name = game.Name,
        SteamAppId = game.SteamAppId,
        AboutTheGame = game.AboutTheGame,
        ShortDescription = game.ShortDescription,
        HeaderImage = game.HeaderImage,
        Website = game.Website,
        Developers = game.Developers,
        Publishers = game.Publishers,
        Genres = game.Genres,
        Screenshots = game.Screenshots,
        MetacriticScore = game.MetacriticScore,
        ReleaseDate = game.ReleaseDate,
        InitialPrice = game.InitialPrice,
        DiscountPercent = game.DiscountPercent,
        Stock = game.Stock
    };

    public static OrderDto OrderToDto(Order order) => new()
    {
        OrderId = order.OrderId,
        User = order.User,
        OrderDate = order.OrderDate,
        OrderStatus = order.OrderStatus,
        TotalOrderPrice = order.TotalOrderPrice,
        ShippingAddress = order.ShippingAddress,
        BillingAddress = order.BillingAddress,
        Games = order.Games.Select(GameToDto).ToList()
    };
}
