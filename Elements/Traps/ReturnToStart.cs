namespace AtrapaABarbie;
public class ReturnToStart : Trap
{
    public ReturnToStart()
    {
        Type = CellType.ReturnToStart;
        Description = "Retorna al inicio";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.X = game.Board.Start.X;
        game.CurrenPlayer.Piece.Y = game.Board.Start.Y;
    }
}