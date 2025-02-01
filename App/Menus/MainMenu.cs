using System;
using System.Threading;
using Spectre.Console;
namespace BarbieSecretGarden;
public static class MainMenu
{
    public static void ShowMenu()
    {
        // "Barbie" title in large and pink
        AnsiConsole.Write(
             new FigletText("Welcome  to  Barbie's  Secret  Garden")
                 .Centered()
                 .Color(Color.HotPink)
         );

            Thread.Sleep(4000);

        // Instructions panel
    var instructionsPanel = new Panel(
            Align.Center(
                new Markup(
                    "This is a fun game set in Barbie's secret garden,\n" + 
                    "where with the character you choose you must try to reach Barbie's favorite flower first: the pink tulip.\n\n" +
                    "This is the path[bold pink1]██[/]\n" +
                    "This is a wall [black]🌳[/]\n" +
                    "[underline]Controls:[/]\n" +
                    "• Use the [bold green]arrow keys[/] (↑, ↓, ←, →) to move around the board.\n" +
                    "• Press [bold red]ESC[/] at any time to exit the game.\n\n" +
                    "[underline]Goal Tile:[/]\n" +
                    "• The goal tile is represented by the symbol [bold yellow]🌷[/].\n" +
                    "• You must reach this tile to win the game!\n\n" +
                    "[underline]Traps:[/]\n" +
                    "• There are hidden traps in the maze.\n" +
                    "• The traps can have the following effects: \n" +
                    "  -  Send you back to the start of the maze.\n" +
                    "  -  Send you back to the start of the maze.\n" +
                    "  -  Reduce your speed by half for one turn.\n" +
                    "  -  Make you lose a turn.\n\n" +
                    "[underline]Special Abilities:[/]\n" +
                    "• Each player has a special ability that they can activate during their turn but not in the next one.\n\n" +
                    "• Use these abilities strategically to outsmart your opponents.\n\n" +
                    "[bold pink1]Good luck and have fun exploring the secret garden![/]"
                ),
                VerticalAlignment.Middle
            )
        )
        {
            Border = BoxBorder.Rounded,
            Header = new PanelHeader("[bold yellow]Read carefully[/]"),
            Padding = new Padding(2, 2, 2, 2)
        };

        // Mostrar el panel de instrucciones.
        AnsiConsole.Write(instructionsPanel);

        // Menu options
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select an option:")
            .AddChoices(new[] {
                "[bold HotPink]New Game[/]", "[bold HotPink]Exit[/]"
            }));
        Console.Clear();
        // Handle selected options
        switch (option)
        {
            case "[bold HotPink]New Game[/]":
            AnsiConsole.MarkupLine("Starting the game...");
            break;
            case "[bold HotPink]Exit[/]":
            AnsiConsole.MarkupLine("Exiting the game...");
            Console.Clear();
            Environment.Exit(0);
            break;
        }
        }
    }
