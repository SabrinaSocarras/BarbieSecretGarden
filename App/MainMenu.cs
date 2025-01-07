using System;
using Spectre.Console;
namespace AtrapaABarbie;
public static class MainMenu
{
    public static void ShowMenu()
    {
        // Título "Barbie" en grande y rosado
        AnsiConsole.MarkupLine("[bold pink1]Barbie[/]");

        // Opciones del menú
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Selecciona una opción:")
                .AddChoices(new[] {
                    "Nueva partida", "Instrucciones", "Salir"
                }));

        // Manejo de las opciones seleccionadas
        switch (option)
        {
            case "Nueva partida":
                AnsiConsole.MarkupLine("Iniciando nueva partida...");
                break;
            case "Instrucciones":
                AnsiConsole.MarkupLine("Aquí van las instrucciones del juego.");
                break;
            case "Salir":
                AnsiConsole.MarkupLine("Saliendo del juego...");
                Console.Clear();
                Environment.Exit(0);
                break;
        }
    }
}
