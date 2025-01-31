using System;
using Spectre.Console;
namespace BarbieSecretGarden;

public static class VictoryMenu
{
    public static void ShowVictoryMenu(string winnerName)
    {
        // Clear console
        Console.Clear();

        // Show victory message with style
        AnsiConsole.Write(
            new FigletText($"{winnerName} wins!")
                .Centered()
                .Color(Color.Gold1)
        );

        AnsiConsole.MarkupLine("[bold green]🎉 Congratulations! 🎉[/]");
        AnsiConsole.MarkupLine($"[bold yellow]{winnerName}[/] has colect the tulip!.");

        // Create a menu with options
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold cyan]What would you like to do now?[/]")
                .PageSize(3)
                .AddChoices(new[]
                {
                    "Return to main menu",
                    "Exit"
                })
        );

        // Handle the selected option
        switch (choice)
        {
            case "Return to main menu":
                AnsiConsole.MarkupLine("[bold green]Returning to main menu...[/]");
                Console.Clear();
                MainMenu.ShowMenu();
                GameMenu gameMenu = new GameMenu();
                Application app = new Application();
                app.Start(gameMenu.Players);
                break;

            case "Exit":
                AnsiConsole.MarkupLine("[bold red]Exiting game...[/]");
                Console.Clear();
                Environment.Exit(0); 
                break;
        }
    }
}