namespace AtrapaABarbie;

public class Game
{
    public List<Piece> Pieces { get; set; } = [];
    public Board Board { get; set; } = null!;
    public Player CurrenPlayer { get; set; } = null!;

    public bool Winner()
    {
        return CurrenPlayer.Piece.X == Board.End.X && CurrenPlayer.Piece.Y == Board.End.Y; //saber cuando el jugador llego a la casilla final
    }
}