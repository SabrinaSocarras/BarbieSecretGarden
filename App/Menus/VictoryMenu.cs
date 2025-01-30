using System;
using Spectre.Console;
namespace AtrapaABarbie;

public static class VictoryMenu
{
    public static void ShowVictoryMenu(string winnerName)
    {
        // Limpiar la consola
        Console.Clear();

        // Mostrar un mensaje de victoria con estilo
        AnsiConsole.Write(
            new FigletText($"¡{winnerName} gana!")
                .Centered()
                .Color(Color.Gold1)
        );

        AnsiConsole.MarkupLine("[bold green]🎉 ¡Felicidades! 🎉[/]");
        AnsiConsole.MarkupLine($"[bold yellow]{winnerName}[/] ha logrado escapar del laberinto.");

        // Crear un menú con opciones
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold cyan]¿Qué deseas hacer ahora?[/]")
                .PageSize(3)
                .AddChoices(new[]
                {
                    "Volver al menú principal",
                    "Salir"
                })
        );

        // Manejar la opción seleccionada
        switch (choice)
        {
            case "Volver al menú principal":
                AnsiConsole.MarkupLine("[bold green]Volviendo al menú principal...[/]");
                Console.Clear();
                MainMenu.ShowMenu();
                GameMenu gameMenu = new GameMenu();
                Application app = new Application();
                app.Start(gameMenu.Players);
                break;

            case "Salir":
                AnsiConsole.MarkupLine("[bold red]Saliendo del juego...[/]");
                Environment.Exit(0); // Cierra la aplicación
                break;
        }
    }
}