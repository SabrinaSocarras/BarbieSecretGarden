namespace AtrapaABarbie;

public class Game
{
    public List<Piece> Pieces { get; set; } = [];
    public Board Board { get; set; } = null!;
    public Player CurrenPlayer { get; set; } = null!;
}