using Spectre.Console;
using System.Threading;

namespace AtrapaABarbie;

public class Application
{
    public Game game { get; set; } = null!;
    public void Start(int cantPlayers)
    {
        Board board = new Board(31);
        List<Piece> pieces = new List<Piece>();
        List<Player> players = new List<Player>();
        for (int i = 0; i < cantPlayers; i++)
        {
            Player player = new Player();
            player.Name = PlayerName.GetName(i + 1);
            PieceSelector pieceSelector = new PieceSelector();
            player.Piece = pieceSelector.ShowMenu(player.Name, pieces);
            pieces.Add(player.Piece);
            Console.WriteLine("");
            player.Piece.X = board.Start.X;
            player.Piece.Y = board.Start.Y;
            players.Add(player);
        }

        game = new Game(board, players.ToArray());
        game.CurrenPlayer = game.Players[0];
        PlayGame();
    }
    public void PlayGame()
    {
        while (!game.Winner())
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine("");
            Console.WriteLine("");
            PlayerAction action = PrintActions();
            if (action == PlayerAction.Activar)
            {
                Skill skill = game.CurrenPlayer.Piece.Skill;
                // game.CurrenPlayer.Piece.Skills[skill].Execute(game);
            }
            else if (action == PlayerAction.Salir)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                AnsiConsole.Markup($"[bold pink1]Turno de {game.CurrenPlayer.Name}[/]");
                Movement(game.CurrenPlayer.Piece);
            }
            if (!game.Winner())
            {
                game.ChangePlayer();
            }

        }
        VictoryMenu.ShowVictoryMenu(game.CurrenPlayer.Name);
    }
    private PlayerAction PrintActions()
    {
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"Select an option {game.CurrenPlayer.Name}:")
                .AddChoices(new[] {
                    "Move", "Activate the skill", "Exit game",
                }));

        switch (option)
        {
            case "Move":
                return PlayerAction.Mover;
            case "Activate the skill":
                return PlayerAction.Activar;
            case "Exit game":
                return PlayerAction.Salir;
            default:
                return PrintActions();
        }

    }
    public void Movement(Piece piece)
    {
        int speed = piece.Speed;
        if (!piece.Moved)
        {
            while (speed > 0)
            {
                if (game.Winner())
                {
                    break;
                }
                if (game.IsInStayInPlace(game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y))
                {
                    Console.WriteLine("");
                    AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} stays in place until next turn.[/]");
                    Thread.Sleep(2000);
                    game.Board.Cells[game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y].Type = CellType.Path;
                    break;
                }
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (piece.Movement(game, -1, 0))
                        {
                            game.CurrenPlayer.Piece.X -= 1;
                            speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (piece.Movement(game, 1, 0))
                        {
                            game.CurrenPlayer.Piece.X += 1;
                            speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (piece.Movement(game, 0, -1))
                        {
                            game.CurrenPlayer.Piece.Y -= 1;
                            speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (piece.Movement(game, 0, 1))
                        {
                            game.CurrenPlayer.Piece.Y += 1;
                            speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

    }
    public void PrintBoard()
    {
        for (int i = 0; i < 31; i++)
        {
            for (int j = 0; j < 31; j++)
            {
                bool playerInCell = false;
                foreach (var player in game.Players)
                {
                    if (player.Piece.X == i && player.Piece.Y == j)
                    {
                        AnsiConsole.Markup($"[black]█[/]");
                        playerInCell = true;
                        break;
                    }
                }

                if (!playerInCell)
                {
                    if (game.Board.Cells[i, j].Type == CellType.Wall)
                    {
                        AnsiConsole.Markup("[green]█[/]");
                    }
                    else if (game.Board.Cells[i, j].Type == CellType.Final)
                    {
                        AnsiConsole.Markup("[blue]|[/]");
                    }
                    else if (game.Board.Cells[i, j].Type == CellType.StayInPlace || game.Board.Cells[i, j].Type == CellType.ReturnToStart)
                    {
                        AnsiConsole.Markup("[red]█[/]");
                    }
                    else
                    {
                        AnsiConsole.Markup("[bold pink1]█[/]");
                    }

                }
                // dibujar a las fichas
            }
            AnsiConsole.WriteLine();
        }
    }
}
