namespace AtrapaABarbie;

public class Skill
{
    public SkillType Type { get; }
    public bool Used {get; set; }
    public virtual void Execute(){}
}