using System;
using AtrapaABarbie;
using Spectre.Console;


public static class Program
{
    static void Main(string[] args)
    {
        MainMenu.ShowMenu();
        GameMenu gameMenu = new GameMenu();
        Application app = new Application();
        app.Start(gameMenu.Players);
    }

}
