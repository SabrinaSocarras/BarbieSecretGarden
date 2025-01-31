namespace BarbieSecretGarden;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public Player Opponent { get; set; } = null!;
    public Piece Piece { get; set; } = null!;

}