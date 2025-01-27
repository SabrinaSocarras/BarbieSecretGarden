namespace AtrapaABarbie;

public class StayInPlace :Trap
{
    public StayInPlace()
    {
        Type = CellType.StayInPlace;
        Description = "If you are in this trap you will stay there and wait for the other round";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.Speed = 0;
    }
}