using RockPaperScissors.Core;

var game = new Game();

Console.WriteLine("Welcome to Rock, Paper, Scissors!");
Console.WriteLine("Implement the console game logic here");

var doRun = true;
while (doRun)
{
    Console.WriteLine("Please enter Rock (1), Paper (2), or Scissors (3).");
    
    var playerInput = Console.ReadLine();
    // parse playerMove, either enum Move or int
    var playerMove = GetPlayerMove(playerInput);
    
    if (playerMove.HasValue)
    {

        var computerMove = (Move)new Random().Next(1, 4);
        
        Console.WriteLine($"You chose {playerMove.Value}, Computer chose {computerMove}");
        
        var result = game.EvaluateResult(playerMove.Value, computerMove);
        switch (result)
        {
            case GameResult.Win:
                Console.WriteLine("You win!");
                break;
            case GameResult.Lose:
                Console.WriteLine("You lose!");
                break;
            case GameResult.Draw:
                Console.WriteLine("It's a draw!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid move.");
    }    

    Console.WriteLine("Do you want to play again? (Y/N)");
    var playAgain = Console.ReadLine();
    if (playAgain?.ToUpper() != "Y")
    {
        doRun = false;
    }
}

return;

Move? GetPlayerMove(string? playerInput)
{
    if (string.IsNullOrWhiteSpace(playerInput))
    {
        return null;
    }
    
    if (int.TryParse(playerInput, out var moveInt))
    {
        return (Move)moveInt;
    }
    
    if (Enum.TryParse<Move>(playerInput, true, out var move))
    {
        return move;
    }
    
    return null;
}
