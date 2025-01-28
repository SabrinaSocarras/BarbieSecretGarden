using System;
using AtrapaABarbie;
using Spectre.Console;


public static class Program
{  
    static void Main(string[] args)
    {
        MainMenu.ShowMenu();
        Board maze = new Board(31);

        // Dibujar el laberinto
        for (int i = 0; i < 31; i++)
        {
            for (int j = 0; j < 31; j++)
            {
            if (maze.Cells[i,j].Type == CellType.Wall)
            {
                AnsiConsole.Markup("[green]█[/]");
            }
            else if (maze.Cells[i,j].Type == CellType.Final){
                AnsiConsole.Markup("[blue]🚪[/]");
            }
            else if (maze.Cells[i,j].Type == CellType.Start) {
                // AnsiConsole.Markup("[red]🚩[/]");
                AnsiConsole.Markup("[bold pink1]👩[/]");
            }
            else
            {
                AnsiConsole.Markup("[bold pink1]█[/]");
            }
            }
            AnsiConsole.WriteLine();
        }
    }

            }
