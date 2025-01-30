using System;
using Spectre.Console;
namespace AtrapaABarbie;
public static class MainMenu
{
    public static void ShowMenu()
    {
        // "Barbie" title in large and pink
        AnsiConsole.MarkupLine("[bold pink1]Welcome to Barbie's Maze[/]");

        // Menu options
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[] {
                    "New Game", "Instructions", "Exit"
                }));
        Console.Clear();
        // Handle selected options
        switch (option)
        {
            case "New Game":
                AnsiConsole.MarkupLine("Starting the game...");
                break;
            case "Instructions":
                AnsiConsole.MarkupLine("Here are the instructions.");
                break;
            case "Exit":
                AnsiConsole.MarkupLine("Exiting the game...");
                Console.Clear();
                Environment.Exit(0);
                break;
        }
    }
}
