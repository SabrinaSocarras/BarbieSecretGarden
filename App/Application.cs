namespace AtrapaABarbie;

public class Application
{
    public Game game { get; set; } = null!;
    public void Start()
    {
        Board board = new Board(6);
        Player player = new Player();
        Game game = new Game();
    }
    public string PlayGame()
    {
        do
        {
            PlayerAction action = PrintActions();
            if (action == PlayerAction.Activar)
            {
                Skill skill = game.CurrenPlayer.Piece.Skill;
                // game.CurrenPlayer.Piece.Skills[skill].Execute(game);
            }
        } while (!game.Winner()); // se repetira el ciclo hasta que uno de los dos jugadores gane 
        return $"The Winner is {game.CurrenPlayer.Name}";
    }
    private PlayerAction PrintActions()
    {
        ShowMassage("Elige una opcion");
        ShowMassage("M: Mover");
        ShowMassage("A: Activar");
        return GetAction();
    }
    private PlayerAction GetAction()
    {
        ConsoleKeyInfo consoleKey = Console.ReadKey();
        switch (consoleKey.Key)
        {
            case ConsoleKey.M:
                return PlayerAction.Mover;
            case ConsoleKey.A:
                return PlayerAction.Activar;
            default:
                return GetAction();  //si elige otra opcion vuelve a llamar al metodo 
        }
    }
    private void ShowMassage(string massage) //creando un metodo para no tener que repetir tanto Console.WriteLine 
    {
        System.Console.WriteLine(massage);
    }

    public void Movement(Piece piece)
    {
        int speed = piece.Speed;
        if (!piece.Moved)
        {
            while (speed > 0)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (piece.Movement(game, -1, 0)) { }
                        break;
                    case ConsoleKey.DownArrow:
                        //Mover Abajo
                        break;
                    case ConsoleKey.LeftArrow:
                        //Mover Izquierda
                        break;
                    case ConsoleKey.RightArrow:
                        //Mover Derecha
                        break;
                    default:
                        break;
                }
            }
        }

    }
    public void PrintBoard()
    {

    }
}