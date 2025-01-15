namespace AtrapaABarbie;

public class Piece
{
    public Piece(string name, string logo ,int speed, params Skill[] skills)
    {
        Name = name;
        Logo = logo;
        Speed = speed;
        _speed = speed;
    }

    public string Name { get; private set; } = String.Empty;
    public string Logo { get; private set; }
    public int Speed { get; set; }
    private int _speed { get; set; }
    public Skill[] Skills { get; } = [];
    public bool Moved { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool Movement(Game game, int modX, int modY)
    {
        //Validar que se pueda mover a las casilla [X + modX, Y + modY] 
        Moved = true;
        return Moved;
    }
    public void SetOrigin()
    {
        Speed = _speed;
        Moved = false;
        foreach (var skill in Skills)
        {
            skill.Used = false;
        }
    }
}