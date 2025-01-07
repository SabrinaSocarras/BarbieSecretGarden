namespace AtrapaABarbie;

public class Application
{
    public Game game {get; set;} = null!;
    public void Start()
    {
        //Inicializar OBJETOS 
        //Crear, tablero, piezas, jugadores y Game
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
                return GetAction();
        }
    }
    private int SelectSkill(Piece piece)
    {
        /*
            int value = int.MaxValue
            while(value > piece.Skills.Count)
            {
                pedir un consoleKey
                swith(consoleKey.Key)
                    case D1:                  Di = i - 1
                        value = 0;
                        break;
                    default:
                        break;
            }
            return value;
        */
        ConsoleKeyInfo consoleKey = Console.ReadKey();
        while (true)
        {
            if (Utils.TranslateNumber.TryGetValue(consoleKey.Key, out int value) && value < piece.Skills.Count)
            {
                return value;
            }
            else
            {
                ShowMassage("Invalid value for the skill");
                consoleKey = Console.ReadKey();
            }
        }
    }
    private void ShowMassage(string massage)
    {
        System.Console.WriteLine(massage);
    }
}