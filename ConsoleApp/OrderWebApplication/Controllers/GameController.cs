using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameWebApplication.Dtos;

namespace GameWebApplication.Controllers;

[ApiController]
[Route("controller/")]
public class GameController : ControllerBase
{
    private static List<GameDto> Games { get; set; } = [];

    // 1. Отримання всіх замовлень
    [HttpGet("all")]
    public ActionResult<List<GameDto>> GetAllGames()
    {
        return Ok(Games);
    }

    // 2. Отримання замовлення за ID
    [HttpGet("{id:int}")]
    public ActionResult<GameDto> GetGameById(int id)
    {
        var Game = Games.FirstOrDefault(o => o.Id == id);
        if (Game == null)
            return NotFound();
        return Ok(Game);
    }

    // 3. Створення нового замовлення
    [HttpPost]
    public ActionResult CreateGame(GameDto newGame)
    {
        newGame.Id = Games.Count != 0 ? Games.Max(o => o.Id) + 1 : 1;
        Games.Add(newGame);
        return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
    }

    // 4. Оновлення замовлення за ID
    [HttpPut("put/{id:int}")]
    public ActionResult UpdateGame(int id, GameDto updatedGame)
    {
        var Game = Games.FirstOrDefault(o => o.Id == id);
        if (Game == null)
            return NotFound();

        Game.CustomerName = updatedGame.CustomerName;
        Game.Amount = updatedGame.Amount;
        Game.Status = updatedGame.Status;
        Game.GameDate = updatedGame.GameDate;

        return NoContent();
    }

    // 5. Видалення замовлення за ID
    [HttpDelete("{id:int}")]
    public ActionResult DeleteGame(int id)
    {
        var Game = Games.FirstOrDefault(o => o.Id == id);
        if (Game == null)
            return NotFound();

        Games.Remove(Game);
        return NoContent();
    }

    // 7. Фільтрація замовлень за статусом
    [HttpGet("status/{status}")]
    public ActionResult<List<GameDto>> GetGamesByStatus(GameStatus status)
    {
        var filteredGames = Games
            .Where(o => o.Status == status)
            .ToList();

        return Ok(filteredGames);
    }
}