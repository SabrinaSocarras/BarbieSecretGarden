namespace AtrapaABarbie;

public class Piece
{
    public string Name { get; private set; } = null!;
    public int Speed { get; set; }
    private int _speed;
    public List<Skill> Skills { get; } = [];
    public bool Moved { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}