using System;
using Spectre.Console;
namespace AtrapaABarbie;
public static class PlayerName
{
    public static string GetName(int number)
    {
        // Solicitar el nombre del jugador

        var name = AnsiConsole.Ask<string>($"Ingresa el nombre del jugador {number}:");

        return name;
    }
}