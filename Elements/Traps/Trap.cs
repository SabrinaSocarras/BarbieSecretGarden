namespace AtrapaABarbie;

public class Trap
{
    public PlaceType Type {get; set; }

    public string Description {get; set; } = string.Empty;

    public virtual void Execute(Game game){ }
}