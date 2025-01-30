using System;
using Spectre.Console;
namespace AtrapaABarbie;
public static class PlayerName
{
    public static string GetName(int number)
    {
        // Solicitar el nombre del jugador

        var name = AnsiConsole.Ask<string>($"Enter player {number} name:");

        return name;
    }
}