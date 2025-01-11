namespace AtrapaABarbie;

public class Application
{
    public Game game { get; set; } = null!;
    public void Start()
    {
        Board board = new Board(6);
        Player player = new Player();
        Game game = new Game();
        Piece piece = new Piece();

    }
    public string PlayGame()
    {
        do
        {
            PlayerAction action = PrintActions();
            if (action == PlayerAction.Activar)
            {
                int skill = SelectSkill(game.CurrenPlayer.Piece);
                game.CurrenPlayer.Piece.Skills[skill].Execute(game);
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
    private int SelectSkill(Piece piece)
    {
        int value = int.MaxValue;
        while (value > piece.Skills.Count)
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            switch (consoleKey.Key)
            {
                case ConsoleKey.D0:
                    value = 0;
                    break;
                case ConsoleKey.D1:
                    value = 1;
                    break;
                case ConsoleKey.D2:
                    value = 2;
                    break;
                case ConsoleKey.D3:
                    value = 3;
                    break;
                case ConsoleKey.D4:
                    value = 4;
                    break;
                case ConsoleKey.D5:
                    value = 5;
                    break;
                case ConsoleKey.D6:
                    value = 6;
                    break;
                case ConsoleKey.D7:
                    value = 7;
                    break;
                case ConsoleKey.D8:
                    value = 8;
                    break;
                case ConsoleKey.D9:
                    value = 9;
                    break;    

                default:
                    break;
            }
            return value;
        }
        return value;
    }
    private void ShowMassage(string massage) //creando un metodo para no tener que repetir tanto Console.WriteLine 
    {
        System.Console.WriteLine(massage);
    }

}


