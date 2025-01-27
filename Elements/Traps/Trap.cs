namespace AtrapaABarbie;

public class Trap
{
    public CellType Type {get; set; }

    public string Description {get; set; } = string.Empty;

    public virtual void Execute(Game game){ }
}