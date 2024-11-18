using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Core;

namespace RockPaperScissors.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGame _game;

    public GameController(IGame game)
    {
        _game = game;
    }

    [HttpPost("play")]
    public IActionResult Play([FromBody] Move move)
    {
        throw new NotImplementedException("Implement the API endpoint here");
    }
}