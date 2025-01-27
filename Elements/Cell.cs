namespace AtrapaABarbie;

public struct Cell
{
    public Cell() { }
    public int X { get; set; }
    public int Y { get; set; }
    public bool Obstacule { get; set; }
    public CellType Type { get; set; } = CellType.None;

    public override string ToString()
    {
        return $"{X},{Y},{Obstacule}";
    }
}