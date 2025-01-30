namespace AtrapaABarbie;

public class StayInPlace :Trap
{
    public StayInPlace()
    {
        Type = CellType.StayInPlace;
        Description = "Lose all piece speed";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.Speed = 0;
    }
}