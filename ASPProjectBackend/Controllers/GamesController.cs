using ASPProjectBackend.Data;
using ASPProjectBackend.Helpers;
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
        public async Task<ActionResult<List<GameDto>>> GetAllGames()
        {
            var games = await context.Games.ToListAsync();
            return games.Select(DtoConverter.GameToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await context.Games.FindAsync(id);

            if (game == null)
            {
                Console.WriteLine("GameDto not found");
                return NotFound();
            }

            return DtoConverter.GameToDto(game);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditGame([FromBody] GameDto gameDto)
        {
            try
            {
                var game = await context.Games.FirstOrDefaultAsync(g => g.Id == gameDto.Id);

                if (game == null)
                {
                    Console.WriteLine("GameDto not found");
                    return NotFound();
                }

                game.Name = gameDto.Name;
                game.SteamAppId = gameDto.SteamAppId;
                game.AboutTheGame = gameDto.AboutTheGame;
                game.ShortDescription = gameDto.ShortDescription;
                game.HeaderImage = gameDto.HeaderImage;
                game.Website = gameDto.Website;
                game.Developers = gameDto.Developers;
                game.Publishers = gameDto.Publishers;
                game.Genres = gameDto.Genres;
                game.Screenshots = gameDto.Screenshots;
                game.MetacriticScore = gameDto.MetacriticScore;
                game.ReleaseDate = gameDto.ReleaseDate;
                game.InitialPrice = gameDto.InitialPrice;
                game.DiscountPercent = gameDto.DiscountPercent;
                game.Stock = gameDto.Stock;

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
                    Console.WriteLine("GameDto not found");
                    return NotFound();
                }

                var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

                if (game == null)
                {
                    Console.WriteLine("GameDto not found");
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
    }
}
