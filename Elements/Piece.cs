namespace AtrapaABarbie;

public class Piece
{
    public string Name { get; private set; } = null!;
    public int Speed { get; set; }
    private int _speed;
    public int Time { get; set; }
    private int _time;
    public List<SkillType> Skills { get; } = [];
    public bool Moved { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}