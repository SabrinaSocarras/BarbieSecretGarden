
namespace AtrapaABarbie;

public class Board
{
    public int Size { get;} 
    public Cell[,] Cells {get; }

    public Board (int size )
    {
        Size = size;
        Cells = new Cell[size,size];
        InitializeBoard();
        //AddRandomTraps();

        MakeBoardAccesible(); 

    }

    private void MakeBoardAccesible()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (Cells[i,j].Type == CellType.Wall)
                {
                    Cells[i,j].Type = CellType.Path;
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
                Cells[i,j] = new Cell(i,j);
            }
        }
    }
     private void GenerateMaze()
     {
        Random rand = new Random();
        int StartX = rand.Next(0,Size);
        int StartY = rand.Next(0,Size);

        Cells[StartX,StartY].Type = CellType.Path;
     }

   
   private List <(int x, int y)> GetNeighbors(int x, int y)
   {
       List<(int , int )> neighbors = new List<(int , int )>();
       if (x > 0)
       {
           neighbors.Add((x-1,y));
       }
       if (x < Size - 1)
       {
           neighbors.Add((x+1,y));
       }
       if (y > 0)
       {
           neighbors.Add((x,y-1));
       }
       if (y < Size - 1)
       {
           neighbors.Add((x,y+1));
       }
       return neighbors;
   }

   
}