using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Core;

namespace RockPaperScissors.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController(IGame game) : ControllerBase
{
    [HttpPost("play")]
    public IActionResult Play([FromBody, ModelBinder(BinderType = typeof(MoveModelBinder))] Move playerMove)
    {
        var computerMove = (Move)new Random().Next(1, 4);

        var result = game.EvaluateResult(playerMove, computerMove);
        return Ok(new PlayResponse
        {
            PlayerMove = playerMove,
            ComputerMove = computerMove,
            Result = result
        });
    }
}