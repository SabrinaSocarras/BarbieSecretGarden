namespace AtrapaABarbie;

public class IncreaseSpeed : Skill
{
    public IncreaseSpeed(int change)
    {
        Change = change;
        Type = SkillType.ChangeSpeed;
        Description = "Change the Speed to a piece on board";
    }

    public int Change { get; }
    public override void Execute(Game game)
    {
        if (Change < 0)
        {
            game.CurrenPlayer.Opponent.Piece.Speed += Change;
        }
        else game.CurrenPlayer.Piece.Speed += Change;
    }
}