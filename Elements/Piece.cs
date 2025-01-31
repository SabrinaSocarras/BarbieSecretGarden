namespace BarbieSecretGarden;

public class Piece
{
    public Piece(string name, int speed, Skill skill, string logo)
    {
        Logo = logo;
        Name = name;
        Logo = "o";
        Speed = speed;
        _speed = speed;
        Skill = skill;
        
    }

    public string Name { get; private set; } = String.Empty;
    public string Logo { get; private set; }
    public int Speed { get; set; }
    private int _speed { get; set; }
    public Skill Skill { get; }
    public bool Moved { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Time = 0;
    public bool Movement(Game game, int modX, int modY)
    {
        // comprobar que no se sale del tablero
        if (X + modX < 0 || X + modX >= game.Board.Size || Y + modY < 0 || Y + modY >= game.Board.Size)
        {
            return false;
        }
        
        if (game.Board.Cells[X + modX, Y + modY].Type == CellType.Wall)
        {
            return false;
        }
        return true;
    }
    public void SetOrigin()
    {
        Speed = _speed;
        Moved = false;
        Skill.Used = false;
    }
}
