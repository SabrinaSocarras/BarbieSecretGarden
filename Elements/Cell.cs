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

}