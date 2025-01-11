using System;
using AtrapaABarbie;
using Spectre.Console;


public static class Program
{  
    static void Main(string[] args)
    {
        MainMenu.ShowMenu();
        // Definir el laberinto
        char[,] maze = {
            { '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', '#' },
            { '#', '#', '#', '#', '#', '#' }
        };

        // Dibujar el laberinto
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] == '#')
                {
                    AnsiConsole.Markup("[blue]█[/]");
                }
                else
                {
                    AnsiConsole.Markup("[white]█[/]");
                }
            }
            AnsiConsole.WriteLine();
        }
    }
}
