namespace AtrapaABarbie;

public struct Place
{
    public Place() { }
    public int X { get; set; }
    public int Y { get; set; }
    public bool Obstacule { get; set; }
    public PlaceType Type { get; set; } = PlaceType.None;

    public override string ToString()
    {
        return $"{X},{Y},{Obstacule}";
    }
}