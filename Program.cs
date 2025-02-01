using System;
using BarbieSecretGarden;
using Spectre.Console;


public static class Program
{
    static void Main(string[] args)
    {
     
        // Frecuencias para las notas musicales
        int doNote = 262;  // Do
        int reNote = 294;  // Re
        int miNote = 330;  // Mi
        int solNote = 392; // Sol
        int laNote = 440;  // La
        int siNote = 494;  // Si

        
        // Melodía alegre y mágica
         Console.Beep(miNote, 500); // Mi
        Console.Beep(solNote, 500); // Sol
        Console.Beep(laNote, 500); // La
        Console.Beep(miNote, 500); // Mi
        Console.Beep(solNote, 500); // Sol
        Console.Beep(laNote, 500); // La
        Console.Beep(siNote, 500); // Si
        Console.Beep(laNote, 500); // La
        Console.Beep(solNote, 500); // Sol
        Console.Beep(miNote, 500); // Mi
        Console.Beep(reNote, 500); // Re
        Console.Beep(doNote, 500); // Do
        Console.Beep(reNote, 500); // Re
        Console.Beep(miNote, 500); // Mi
        Console.Beep(miNote, 500); // Mi
        Console.Beep(reNote, 1000); // Re (más largo)
        Console.Beep(doNote, 1000);
        

        MainMenu.ShowMenu();
        GameMenu gameMenu = new GameMenu();
        Application app = new Application();
        app.Start(gameMenu.Players);
        
    }

}
