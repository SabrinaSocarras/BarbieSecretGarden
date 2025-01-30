using System;
using Spectre.Console;
namespace AtrapaABarbie;
public static class MainMenu
{
    public static void ShowMenu()
    {
        // Título "Barbie" en grande y rosado
        AnsiConsole.MarkupLine("[bold pink1]Welcome to the Secret Garden of Barbie[/]");

        // Opciones del menú
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[] {
                    "New Game", "Instructions", "Exit"
                }));
        Console.Clear();
        // Manejo de las opciones seleccionadas
        switch (option)
        {
            case "New Game":
                AnsiConsole.MarkupLine("Starting new game...");
                break;
            case "Instructions":
                AnsiConsole.MarkupLine("Here are the game instructions.");
                break;
            case "Exit":
                AnsiConsole.MarkupLine("Exiting game...");
                Console.Clear();
                Environment.Exit(0);
                break;
        }
    }
}
