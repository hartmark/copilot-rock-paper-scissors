using System.Text.Json.Serialization;
using RockPaperScissors.Core;

namespace RockPaperScissors.Api.Controllers;

public class PlayResponse
{
    [JsonConverter(typeof(EnumStringAndIntConverter<Move>))]
    public Move PlayerMove { get; set; }

    [JsonConverter(typeof(EnumStringAndIntConverter<Move>))]
    public Move ComputerMove { get; set; }

    [JsonConverter(typeof(EnumStringAndIntConverter<GameResult>))]
    public GameResult Result { get; set; }
}