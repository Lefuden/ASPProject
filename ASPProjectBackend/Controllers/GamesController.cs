using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var games = await context.Games.ToListAsync();
            var gameDtoList = games.Select(GameToDto).ToList();

            return gameDtoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await context.Games.FindAsync(id);

            if (game == null)
            {
                Console.WriteLine("Game not found");
                return NotFound();
            }

            return GameToDto(game);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditGame(int id, UpdateGame updateGame)
        {
            try
            {
                var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

                if (game == null)
                {
                    Console.WriteLine("Game not found");
                    return NotFound();
                }

                game.Name = updateGame.Name;
                //game.SteamAppId = updateGame.SteamAppId;
                //game.AboutTheGame = updateGame.AboutTheGame;
                //game.ShortDescription = updateGame.ShortDescription;
                //game.HeaderImage = updateGame.HeaderImage;
                //game.Website = updateGame.Website;
                //game.Developers = updateGame.Developers;
                //game.Publishers = updateGame.Publishers;
                //game.Genres = updateGame.Genres;
                //game.Screenshots = updateGame.Screenshots;
                //game.MetacriticScore = updateGame.MetacriticScore;
                //game.ReleaseDate = updateGame.ReleaseDate;
                game.InitialPrice = updateGame.InitialPrice;
                game.DiscountPercent = updateGame.DiscountPercent;

                context.Update(game);
                await context.SaveChangesAsync();
                return Ok();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteGame(int? id)
        {
            try
            {
                if (id == null)
                {
                    Console.WriteLine("Game not found");
                    return NotFound();
                }

                var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

                if (game == null)
                {
                    Console.WriteLine("Game not found");
                    return NotFound();
                }

                context.Games.Remove(game);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }

        }

        private static GameDto GameToDto(Game game) => new()
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
            DiscountPercent = game.DiscountPercent
        };
    }
}
