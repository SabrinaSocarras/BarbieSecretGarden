namespace AtrapaABarbie;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public Player Opponent { get; set; } = null!;
    public Piece Piece { get; set; } = null!;

    public void ActivateSkill(Game game, int skill)
    {
        Piece.Skills[skill].Execute(game);
    }
}