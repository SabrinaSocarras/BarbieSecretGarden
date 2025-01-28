namespace AtrapaABarbie;

public struct Cell
{
    public Cell(int x, int y) { 
        X = x;
        Y = y;
        Type = CellType.Wall;
     }
    public int X { get; set; }
    public int Y { get; set; }
    public CellType Type { get; set; } = CellType.None;

    public override string ToString()
    {
        switch (Type)
        {
            case CellType.None:
                return " ";
            case CellType.Final:
                return "*";
            case CellType.ReturnToStart:
                return "R";
            case CellType.StayInPlace:
                return "S";
            case CellType.Wall:
                return "#";
            case CellType.Path:
                return " ";
            case CellType.Start:
                return "S";
            default:
                return " ";
        }
    }
}