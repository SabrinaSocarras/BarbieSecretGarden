namespace BarbieSecretGarden;

public class Game
{
    public List<Piece> Pieces { get; set; } = [];
    public Board Board { get; set; } = null!;
    public Player CurrenPlayer { get; set; } = null!;
    public List<Player> Players { get; set; } = [];

    public Game(Board board, params Player[] players)
    {
        Board = board;
        Players.AddRange(players);
    }

    public bool Winner()
    {
        return CurrenPlayer.Piece.X == Board.Exit.X && CurrenPlayer.Piece.Y == Board.Exit.Y;
    }

    public bool IsInStayInPlace(int x, int y)
    {
        return Board.Cells[x, y].Type == CellType.StayInPlace;
    }

    public bool HasSpeedReduction(int x, int y)
    {
        return Board.Cells[x, y].Type == CellType.SpeedReduction;
    }
    
    public bool hasReturnToStart(int x, int y)
    {
        return Board.Cells[x, y].Type == CellType.ReturnToStart;
    }
    

    public void ChangePlayer()
    {
        if (Players.IndexOf(CurrenPlayer) == Players.Count - 1)
        {
            CurrenPlayer = Players[0];
        }
        else
        {
            CurrenPlayer = Players[Players.IndexOf(CurrenPlayer) + 1];
        }   
    }
}
