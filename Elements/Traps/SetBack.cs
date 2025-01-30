namespace AtrapaABarbie;

public class SetBack : Trap
{
    public SetBack()
    {
        Type = CellType.SetBack;
        Description = "Go back 3 spaces";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.X -= 3;
    }
}