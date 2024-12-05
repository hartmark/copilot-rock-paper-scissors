using RockPaperScissors.Core;

namespace RockPaperScissors.Tests;

public class GameTests
{
    [Theory]
    [InlineData(Move.Rock, Move.Scissors, GameResult.Win)]
    [InlineData(Move.Rock, Move.Paper, GameResult.Lose)]
    [InlineData(Move.Rock, Move.Rock, GameResult.Draw)]
    
    [InlineData(Move.Paper, Move.Scissors, GameResult.Lose)]
    [InlineData(Move.Paper, Move.Paper, GameResult.Draw)]
    [InlineData(Move.Paper, Move.Rock, GameResult.Win)]
    
    [InlineData(Move.Scissors, Move.Scissors, GameResult.Draw)]
    [InlineData(Move.Scissors, Move.Paper, GameResult.Win)]
    [InlineData(Move.Scissors, Move.Rock, GameResult.Lose)]
    public void EvaluateResult_ShouldReturnValidResult(Move playerMove, Move computerMove, GameResult expectedResult)
    {
        // Arrange
        var game = new Game();

        // Act
        var result = game.EvaluateResult(playerMove, computerMove);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}