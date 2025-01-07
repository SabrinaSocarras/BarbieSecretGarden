namespace AtrapaABarbie;

public class DoubleTurn : Skill 
{
    public DoubleTurn()
    {
        Type = SkillType.DoubleTurn ;
        Description = "The cureent players can play twice but the opponent can not play";
    }
    public override void Execute(Game game)
    {
        foreach (var skill in game.CurrenPlayer.Piece.Skills)
        {
            if(skill.Type == SkillType.DoubleTurn) continue;
            skill.Used = false;
        }
        game.CurrenPlayer.Piece.Moved = false;
    }
}