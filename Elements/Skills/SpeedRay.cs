namespace BarbieSecretGarden;

public class SpeedRay : Skill
{
    public SpeedRay()
    {
        Name = "Speed Ray";
        Type = SkillType.SpeedRay;
        Description = "Allows double speed movement for the next turn.";
    }

    public override void Execute(Game game)
    {
        if (!Used)
        {

            game.CurrenPlayer.Piece.Speed *= 2;
            Used = true;
            Console.WriteLine($"{game.CurrenPlayer.Name} ha usado {Name}. ¡Ahora puede moverse el doble de distancia!");
        }
        else
        {
            Console.WriteLine("La habilidad ya ha sido usada en este turno.");
        }
    }
}

