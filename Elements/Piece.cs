namespace BarbieSecretGarden;

public class Piece
{
    public Piece(string name, int speed1, Skill skill, string logo)
    {
        Logo = logo;
        Name = name;
        Logo = logo;
        Speed = speed1;
        speed = speed1;
        Skill = skill;
        
    }

    public string Name { get; private set; } = String.Empty;
    public string Logo { get; private set; }
    public int Speed { get; set; }
    public int speed { get; set; }
    public Skill Skill { get; }
    public bool Moved { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
     public int time = 0;
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
    
}
