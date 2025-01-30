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
                .Title("Elige la cantidad de jugadores:")
                .AddChoices(new[] {
                    "2", "3", "4"
                }));

        // Manejo de las opciones seleccionadas
        switch (option)
        {
            case "2":
                AnsiConsole.MarkupLine("Ha seleccionado 2 jugadores");
                Players = 2;
                break;
            case "3":
                AnsiConsole.MarkupLine("Ha seleccionado 3 jugadores");
                Players = 3;
                break;
            case "4":
                AnsiConsole.MarkupLine("Ha seleccionado 4 jugadores");
                Players = 4;
                break;
        }
    }
}
