namespace AtrapaABarbie;

public class StayInPlace :Trap
{
    public StayInPlace()
    {
        Type = CellType.StayInPlace;
        Description = "Pierdes toda la velocidad de la ficha";
    }
    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.Speed = 0;
    }
}