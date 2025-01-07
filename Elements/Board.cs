
namespace AtrapaABarbie;

public class Board
{
    public Place[,] Cells { get; set; } = null!;
    public Board(int n)
    {
        Cells = new Place[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Cells[i, j] = new Place
                {
                    X = i,
                    Y = j,
                    Obstacule = true,
                };
            }
        }
        Cells[0, 0].Obstacule = false;
        BuildBoard(Cells);
    }

    private void BuildBoard(Place[,] board)
    {
        List<Place> places = new List<Place>();
        places.Add(board[0, 0]);

        Place final = places.Last();
        while (places.Count > 0)
        {
            Place current = places.Last();
            places.RemoveAt(places.Count - 1);
            List<(int, int)> directions = new List<(int, int)> { (1, 0), (-1, 0), (0, 1), (0, -1) };
            Shuffle(directions);
            foreach (var dir in directions)
            {
                int nx = current.X + dir.Item1;
                int ny = current.Y + dir.Item2;
                if (nx >= 0 && nx < board.GetLength(0) && ny >= 0 && ny < board.GetLength(1) && board[nx, ny].Obstacule)
                {
                    board[nx, ny].Obstacule = false;
                    places.Add(board[nx, ny]);
                    break;
                }
            }
        }
    }
    private void Shuffle(List<(int, int)> places)
    {
        Random r = new Random();
        int n = places.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            (int, int) p = places[k];
            places[k] = places[n];
            places[n] = p;
        }
    }
}