using WebApplication1.Models.Dto;
namespace WebApplication1.Data
{
    public class GameStore
    {
        public static List<GameDTO> Games = new List<GameDTO>
        {
            new GameDTO {Id = 1, Name = "00000" },
            new GameDTO {Id = 2, Name = "22222" }
        };
    }
}
