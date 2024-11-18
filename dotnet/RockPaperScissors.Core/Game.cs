namespace RockPaperScissors.Core;

public enum Move
{
    Rock,
    Paper,
    Scissors
}

public enum GameResult
{
    Win,
    Lose,
    Draw
}

public interface IGame
{
    GameResult Play(Move playerMove);
}

public class Game : IGame
{
    public GameResult Play(Move playerMove)
    {
        throw new NotImplementedException("Implement the game logic here");
    }
}