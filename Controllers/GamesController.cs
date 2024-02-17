using Microsoft.AspNetCore.Mvc;

namespace JashariDenisLB_295_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private static List<Game> games = new List<Game>();

        // GET: /games
        [HttpGet]
        public ActionResult<List<Game>> GetAllGames()
        {
            return Ok(games);
        }

        // POST: /games
        [HttpPost]
        public ActionResult<Game> AddGame([FromBody] Game game)
        {
            games.Add(game);
            return CreatedAtAction(nameof(GetGameById), new { gameId = game.GameId }, game);
        }

        // GET: /games/{gameId}
        [HttpGet("{gameId}")]
        public ActionResult<Game> GetGameById(int gameId)
        {
            var game = games.FirstOrDefault(g => g.GameId == gameId);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // PUT: /games/{gameId}
        [HttpPut("{gameId}")]
        public ActionResult UpdateGame(int gameId, [FromBody] Game gameUpdate)
        {
            var game = games.FirstOrDefault(g => g.GameId == gameId);
            if (game == null)
            {
                return NotFound();
            }
            game.Title = gameUpdate.Title;
            game.ReleaseDate = gameUpdate.ReleaseDate;
            game.Description = gameUpdate.Description;
            return NoContent();
        }

        // DELETE: /games/{gameId}
        [HttpDelete("{gameId}")]
        public ActionResult DeleteGame(int gameId)
        {
            var game = games.FirstOrDefault(g => g.GameId == gameId);
            if (game == null)
            {
                return NotFound();
            }
            games.Remove(game);
            return NoContent();
        }
    }
}
