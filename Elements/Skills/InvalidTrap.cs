namespace AtrapaABarbie;

public class InvalidTrap : Skill 
{
    public InvalidTrap( )
    {
        Type = SkillType.InvalidTrap;
        Description = "The current player can invalid a trap, even if the trap was putted from the opponent ";
    }
}