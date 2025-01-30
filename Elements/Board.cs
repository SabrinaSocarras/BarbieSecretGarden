namespace AtrapaABarbie;

public class Board
{
    public int Size { get; }
    public Cell[,] Cells { get; }
    public Cell Exit { get; set; }
    public Cell Start { get; set; }

    public Board(int size)
    {
        Size = size;
        Cells = new Cell[size, size];
        InitializeBoard();
        GenerateMaze();
        GenerateExit();
        GenerateStart();
        GenerateTraps();

    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Cells[i, j] = new Cell(i, j);
            }
        }
    }
    private void GenerateMaze()
    {
        Random rand = new Random();
        int StartX = rand.Next(0, Size);
        int StartY = rand.Next(0, Size);

        GenerateMazePrim(StartX, StartY);
    }

    private List<(int x, int y)> GetNeighbors(int x, int y)
    {
        List<(int, int)> neighbors = new List<(int, int)>();
        if (x > 1)
        {
            neighbors.Add((x - 2, y));
        }
        if (x < Size - 2)
        {
            neighbors.Add((x + 2, y));
        }
        if (y > 1)
        {
            neighbors.Add((x, y - 2));
        }
        if (y < Size - 2)
        {
            neighbors.Add((x, y + 2));
        }
        return neighbors;
    }

    private static readonly Random rand = new();
    private void GenerateMazePrim(int x, int y)
    {
        List<(int, int)> frontier = new();
        Cells[x, y].Type = CellType.Path;
        frontier.AddRange(GetNeighbors(x, y));

        while (frontier.Count > 0)
        {
            int index = rand.Next(frontier.Count);
            (int nx, int ny) = frontier[index];
            frontier.RemoveAt(index);

            var connectedCells = new List<(int, int)>();

            var newNeighbors = GetNeighbors(nx, ny);
            foreach (var n in newNeighbors)
                if (Cells[n.x, n.y].Type == CellType.Path)
                    connectedCells.Add(n);

            if (connectedCells.Count != 0)
            {
                var connected = connectedCells[rand.Next(connectedCells.Count)];
                Cells[nx, ny].Type = CellType.Path;
                Cells[(nx + connected.Item1) / 2, (ny + connected.Item2) / 2].Type = CellType.Path;

                foreach (var n in GetNeighbors(nx, ny))
                    if (Cells[n.x, n.y].Type == CellType.Wall && !frontier.Contains(n))
                        frontier.Add(n);
            }
        }
    }


    public void GenerateExit()
    {
        int x = rand.Next(0, Size);
        int y = rand.Next(0, Size);
        while (Cells[x, y].Type == CellType.Wall)
        {
            x = rand.Next(0, Size);
            y = rand.Next(0, Size);
        }
        Cells[x, y].Type = CellType.Final;
        Exit = Cells[x, y];
    }
    public void GenerateStart()
    {
        int x = rand.Next(0, Size);
        int y = rand.Next(0, Size);
        while (Cells[x, y].Type == CellType.Wall)
        {
            x = rand.Next(0, Size);
            y = rand.Next(0, Size);
        }
        Cells[x, y].Type = CellType.Start;
        Start = Cells[x, y];
    }

    public void GeneratePiece(Piece piece)
    {
        piece.X = Start.X;
        piece.Y = Start.Y;
    }

    public void GenerateTraps()
    {
        int traps = 2;
        for (int i = 0; i < traps; i++)
        {
            int x = rand.Next(0, Size);
            int y = rand.Next(0, Size);
            while (Cells[x, y].Type == CellType.Wall || Cells[x, y].Type == CellType.Start || Cells[x, y].Type == CellType.Final)
            {
                x = rand.Next(0, Size);
                y = rand.Next(0, Size);
            }

            Cells[x, y].Type = CellType.StayInPlace;
        }
        for (int i = 0; i < traps; i++)
        {
            int x = rand.Next(0, Size);
            int y = rand.Next(0, Size);
            while (Cells[x, y].Type == CellType.Wall || Cells[x, y].Type == CellType.Start || Cells[x, y].Type == CellType.Final || Cells[x, y].Type == CellType.StayInPlace)
            {
                x = rand.Next(0, Size);
                y = rand.Next(0, Size);
            }

            Cells[x, y].Type = CellType.ReturnToStart;
        }
    }


}
