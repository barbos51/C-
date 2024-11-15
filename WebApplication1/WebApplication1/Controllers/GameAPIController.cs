using WebApplication1.Data;
using WebApplication1.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/GameAPI")]
    [ApiController]
    public class GameAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public GameAPIController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/<VillaAPIController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GameDTO>> GetGames()
        {
            return Ok(_db.Game);
        }

        // GET api/<GameAPIController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameDTO> GetGame(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var game = _db.Game.FirstOrDefault(u => u.Id == id);
            if (game == null)
            {
                return BadRequest();
            }
            return Ok(game);
        }
        //Post api/<GameAPIController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameDTO> CreateGame([FromBody] Game GameDTO)
        {
            if (GameDTO == null)
            {
                return BadRequest(GameDTO);
            }
            if (GameDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            GameDTO.Name = GameDTO.Name + "test";
            _db.Game.Add(GameDTO);

            _db.SaveChanges();

            return Ok(GameDTO);

        }
        // PUT api/<GameAPIController>/5
        [HttpPut("{id}")]
        public ActionResult<GameDTO> UpdateGame([FromBody] GameDTO GameDTO)
        {
            if (GameDTO == null)
            {
                return BadRequest(GameDTO);
            }
            if (GameDTO.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
        // DELETE api/<GameAPIController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameDTO> DeleteGame(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var game = _db.Game.FirstOrDefault(u => u.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            _db.Game.Remove(game);

            _db.SaveChanges();

            return Ok(game);

        }
    }


}
