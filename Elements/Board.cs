
using System.Dynamic;

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
        SetPieces();
        GeneratePiece(new Piece("Barbie Estrella", 4, new Skill("Salto Estelar", 3, "Permite saltar sobre un obstáculo o trampa, moviéndose hasta 2 casillas adicionales en línea recta."), "👩"));


        // MakeBoardAccesible(); 

    }

    public string Cell(int x, int y)
    {
        return Cells[x, y].Type.ToString();
    }

    private void MakeBoardAccesible()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (Cells[i, j].Type == CellType.Wall)
                {
                    Cells[i, j].Type = CellType.Path;
                }
            }
        }
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
        Console.WriteLine("Maze generated");
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

    public static void SetPieces()
        {
            // Crear habilidades para las fichas con sus descripciones
            var saltoEstelar = new Skill("Salto Estelar", 3, "Permite saltar sobre un obstáculo o trampa, moviéndose hasta 2 casillas adicionales en línea recta.");

            var ganchoAventurero = new Skill("Gancho de Aventurero", 4, "Lanza un gancho para moverse a cualquier casilla en línea recta dentro de un radio de 5 casillas, ignorando obstáculos.");

            var trampaInversa = new Skill("Trampa Inversa", 2, "Convierte una trampa en una casilla de beneficio (por ejemplo, otorga un movimiento extra) durante 1 turno.");

            var bolaCristal = new Skill("Bola de Cristal", 5, "Invalida la habilidad de la ficha contraria durante el proximo turno.");

            var rayoVeloz = new Skill("Rayo Veloz", 3, "Permite moverse el doble de la velocidad durante 1 turno, pero no se pueden usar habilidades en ese turno.");

            // Crear las fichas con sus habilidades
            // var barbieEstrella = new Piece("Barbie Estrella", 4, saltoEstelar);
            // var kenAventurero = new Piece("Ken Aventurero", 3, ganchoAventurero);
            // var skipperInventora = new Piece("Skipper Inventora", 2, trampaInversa);
            // var barbieMagica = new Piece("Barbie Mágica", 3, bolaCristal);
            // var chelseaExploradora = new Piece("Chelsea Exploradora", 5, rayoVeloz);

            // Mostrar información de las fichas creadas
            // Console.WriteLine("Fichas creadas:");
            // Console.WriteLine("----------------");
            // DisplayPieceInfo(barbieEstrella);
            // DisplayPieceInfo(kenAventurero);
            // DisplayPieceInfo(skipperInventora);
            // DisplayPieceInfo(barbieMagica);
            // DisplayPieceInfo(chelseaExploradora);
        }

        public static void DisplayPieceInfo(Piece piece)
        {
            Console.WriteLine($"Nombre: {piece.Name}");
            Console.WriteLine($"Velocidad: {piece.Speed}");
            Console.WriteLine("Habilidades:");
            Console.WriteLine($"- {piece.Skill.Name} (Enfriamiento: {piece.Skill.Cooldown} turnos)");
            Console.WriteLine($"  Descripción: {piece.Skill.Description}");
            Console.WriteLine("----------------");
        }

}