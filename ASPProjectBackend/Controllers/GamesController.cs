using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            var gameDtoList = games.Select(GameToDto).ToList();

            return gameDtoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return GameToDto(game);
        }

        private static GameDto GameToDto(Game game) => new GameDto
        {
            Id = game.Id,
            Name = game.Name,
            SteamAppId = game.SteamAppId,
            //IsFree = game.IsFree,
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
            //ComingSoon = game.ComingSoon,
            InitialPrice = game.InitialPrice,
            DiscountPercent = game.DiscountPercent
        };
    }
}
