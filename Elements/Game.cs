namespace AtrapaABarbie;

public class Game
{
    public List<Piece> Pieces { get; set; } = [];
    public Board Board { get; set; } = null!;
    public Player CurrenPlayer { get; set; } = null!;

    public bool Winner()
    {
        return CurrenPlayer.Piece.X == Board.Exit.X && CurrenPlayer.Piece.Y == Board.Exit.Y;
    }
}