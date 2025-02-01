using Spectre.Console;

namespace BarbieSecretGarden;

public class SpeedRay : Skill
{
    public SpeedRay()
    {
        Name = "Speed Ray";
        Type = SkillType.SpeedRay;
        Description = "Allows double speed movement for the next turn.";
        Cooldown = 2;
    }

    public override void Execute(Game game)
    {
        game.CurrenPlayer.Piece.Speed*= 2;
       
        Thread.Sleep(2000);
    }
}

