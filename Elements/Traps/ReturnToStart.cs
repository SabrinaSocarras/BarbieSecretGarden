namespace AtrapaABarbie;
public class ReturnToStart : Trap
{
    public ReturnToStart()
    {
        Type = CellType.ReturnToStart;
        Description = "If you are in this trap you return to the start";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.X = 0;
        game.CurrenPlayer.Piece.Y = 0;
    }
}