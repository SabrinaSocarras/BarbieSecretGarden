namespace AtrapaABarbie;

public static class Program
{
    static void Main(string[] args)
    {
        Board board = new Board(10);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (board.Cells[i,j].Obstacule)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write(board.Cells[i,j].Obstacule + " ");
            }
            System.Console.WriteLine();
        }
    }
}