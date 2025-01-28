namespace AtrapaABarbie;

public class DoubleTurn : Skil
{
    public DoubleTurn()
    {
        Type = SkillType.DoubleTurn ;
        Description = "The cureent players can play twice but the opponent can not play";
    }
    public override void Execute(Game game)
    {
        
        game.CurrenPlayer.Piece.Moved = false;
    }
}