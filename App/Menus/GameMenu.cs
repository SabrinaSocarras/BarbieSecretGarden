using Spectre.Console;
namespace AtrapaABarbie;

public class GameMenu
{
    public int Players { get; set; }
    public GameMenu()
    {
        ShowMenu();
    }
    public void ShowMenu()
    {
        // Opciones del menú
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose number of players:")
                .AddChoices(new[] {
                    "2", "3", "4"
                }));

        // Manejo de las opciones seleccionadas
        switch (option)
        {
            case "2":
                AnsiConsole.MarkupLine("Selected 2 players");
                Players = 2;
                break;
            case "3":
                AnsiConsole.MarkupLine("Selected 3 players");
                Players = 3;
                break;
            case "4":
                AnsiConsole.MarkupLine("Selected 4 players");
                Players = 4;
                break;
        }
    }
}
