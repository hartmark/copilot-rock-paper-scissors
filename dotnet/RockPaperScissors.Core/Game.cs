namespace RockPaperScissors.Core;

public enum Move
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum GameResult
{
    Win = 1,
    Lose = 2,
    Draw = 3
}

public interface IGame
{
    GameResult EvaluateResult(Move playerMove, Move computerMove);
}

public class Game : IGame
{
    public GameResult EvaluateResult(Move playerMove, Move computerMove)
    {
        if (playerMove == computerMove)
        {
            return GameResult.Draw;
        }

        return (playerMove, computerMove) switch
        {
            (Move.Rock, Move.Scissors) => GameResult.Win,
            (Move.Paper, Move.Rock) => GameResult.Win,
            (Move.Scissors, Move.Paper) => GameResult.Win,
            _ => GameResult.Lose
        };
    }
}