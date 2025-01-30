namespace AtrapaABarbie
{
    public class SpeedReduction : Trap
    {
        public SpeedReduction()
        {
            Type = CellType.SpeedReduction;
            Description = "Reduce speed by 1";
        }
        public override void Execute(Game game)
        {
            game.CurrenPlayer.Piece.Speed -= 1;
        }
    }
}