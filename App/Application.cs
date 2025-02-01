using Spectre.Console;
using System.Threading;

namespace BarbieSecretGarden;

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
                game.CurrenPlayer.Piece.time = game.CurrenPlayer.Piece.Skill.Cooldown;
                game.CurrenPlayer.Piece.Skill.Execute(game);
                AnsiConsole.Markup($"{game.CurrenPlayer.Name} has activated their skill {game.CurrenPlayer.Piece.Skill.Name}.");
                Thread.Sleep(2000);
                action = PlayerAction.Mover;
            }
            if (action == PlayerAction.Salir)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            if (action == PlayerAction.Mover)
            {
                AnsiConsole.Markup($"[bold pink1]{game.CurrenPlayer.Name} turn[/]");
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
        List<string> options = new List<string>() { "Move", "Activate the skill", "Exit game" };
        if (game.CurrenPlayer.Piece.time != 0)
        {
            game.CurrenPlayer.Piece.time -= 1;
            options.Remove("Activate the skill");
            AnsiConsole.WriteLine($"¡{game.CurrenPlayer.Name} has used your ability before so can't use it now.");
        }


        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"Select an option {game.CurrenPlayer.Name}:")
                .AddChoices(options.ToArray()
                ));

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
        if (game.CurrenPlayer.Piece.time != 0)
        {
            game.CurrenPlayer.Piece.time -= 1;
            Thread.Sleep(2000);
        }
        piece.speed = piece.Speed;
        if (!piece.Moved)
        {
            while (piece.speed > 0)
            {
                if (game.Winner())
                {
                    break;
                }
                if (game.IsInStayInPlace(game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y))
                {
                    Console.WriteLine("");
                    AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} stays in place until next turn.[/]");
                    Thread.Sleep(4000);
                    game.Board.Cells[game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y].Type = CellType.Path;
                    break;
                }
                if (game.HasSpeedReduction(game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y))
                {
                    piece.Speed /= 2;
                    Console.WriteLine("");
                    AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has fallen into a speed reduction trap.Now you have the half of your moves.[/]");
                    Thread.Sleep(4000);
                    game.Board.Cells[game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y].Type = CellType.Path;
                }

                if (game.hasReturnToStart(game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y))
                {
                    Console.WriteLine("");
                    AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has fallen into a trap and returns to the start.[/]");
                    Thread.Sleep(4000);
                    game.Board.Cells[game.CurrenPlayer.Piece.X, game.CurrenPlayer.Piece.Y].Type = CellType.Path;
                    game.CurrenPlayer.Piece.X = game.Board.Start.X;
                    game.CurrenPlayer.Piece.Y = game.Board.Start.Y;
                    break;
                }

                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (piece.Movement(game, -1, 0))
                        {
                            game.CurrenPlayer.Piece.X -= 1;
                            piece.speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {piece.speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (piece.Movement(game, 1, 0))
                        {
                            game.CurrenPlayer.Piece.X += 1;
                            piece.speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {piece.speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (piece.Movement(game, 0, -1))
                        {
                            game.CurrenPlayer.Piece.Y -= 1;
                            piece.speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {piece.speed} moves left. [/]");
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (piece.Movement(game, 0, 1))
                        {
                            game.CurrenPlayer.Piece.Y += 1;
                            piece.speed--;
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("");
                            AnsiConsole.Markup($"[bold pink1]¡{game.CurrenPlayer.Name} has {piece.speed} moves left. [/]");
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
                        AnsiConsole.Markup($"[black]{player.Piece.Logo}[/]");

                        playerInCell = true;
                        break;
                    }
                }

                if (!playerInCell)
                {
                    if (game.Board.Cells[i, j].Type == CellType.Wall)
                    {
                        AnsiConsole.Markup("[black]🌳[/]");
                    }
                    else if (game.Board.Cells[i, j].Type == CellType.Final)
                    {
                        AnsiConsole.Markup("[black]🌷[/]");
                    }
                    else if (game.Board.Cells[i, j].Type == CellType.ReturnToStart || game.Board.Cells[i, j].Type == CellType.StayInPlace)
                    {
                        AnsiConsole.Markup("[bold pink1]██[/]");
                    }
                    else if (game.Board.Cells[i, j].Type == CellType.SpeedReduction)
                    {
                        AnsiConsole.Markup("[bold pink1]██[/]");
                    }
                    else
                    {
                        AnsiConsole.Markup("[bold pink1]██[/]");
                    }

                }
               
            }
            AnsiConsole.WriteLine();
        }
    }
}
