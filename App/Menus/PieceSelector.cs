using System;
using Spectre.Console;
namespace AtrapaABarbie;
public class PieceSelector
{

    public Piece ShowMenu(string name, List<Piece> selectedPiece)
    {
        Console.WriteLine("");
        var table = new Table()
               .Border(TableBorder.Heavy)
               .AddColumn(new TableColumn("[bold]Ficha[/]").Centered())
               .AddColumn(new TableColumn("[bold]Habilidad[/]").Centered())
               .AddColumn(new TableColumn("[bold]Descripción[/]").Centered());	

        table.AddRow("Barbie Estrella", "Brillo Estelar", "Permite saltar sobre un obstáculo o trampa.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Ken Aventurero", "Escudo Protector", "Permite moverse en un radio de 5 casillas en línea recta.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Skipper Inventora", "Dron Explorador", "Convierte una trampa en un turno extra.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Barbie Mágica", "Hechizo de Teletransportación", "Se teletransporta aleatoriamente a otra casilla.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Chelsea Exploradora", "Rayo Veloz", "Permite moverse el doble de la velocidad durante 1 turno.");

        AnsiConsole.Write(table);
        Console.WriteLine("");
        // Opciones del menú
        List<string> choices = new List<string>() { "Barbie Estrella", "Ken Aventurero", "Skipper Inventora", "Barbie Mágica", "Chelsea Exploradora" };
        foreach (var piece in selectedPiece)
        {
            choices.Remove(piece.Name);
        }
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title($"{name}, selecciona una ficha para jugar:")
            .AddChoices(choices.ToArray()));

        AnsiConsole.MarkupLine($"Has seleccionado la ficha: [bold]{option}[/]");



        // Manejo de las opciones seleccionadas
        switch (option)
        {
            case "Barbie Estrella":
                return new Piece("Barbie Estrella", 500, new Skill("Salto Estelar", 3, "Permite saltar sobre un obstáculo o trampa, moviéndose hasta 2 casillas adicionales en línea recta."), "👩", 2);
            case "Ken Aventurero":
                return new Piece("Ken Aventurero", 3, new Skill("Gancho de Aventurero", 4, "Lanza un gancho para moverse a cualquier casilla en línea recta dentro de un radio de 5 casillas, ignorando obstáculos."), "👨", 2);
            case "Skipper Inventora":
                return new Piece("Skipper Inventora", 2, new Skill("Trampa Inversa", 2, "Convierte una trampa en una casilla de beneficio (por ejemplo, otorga un movimiento extra) durante 1 turno."), "👩‍🔧", 2);
            case "Barbie Mágica":
                return new Piece("Barbie Mágica", 3, new Skill("Bola de Cristal", 5, "Invalida la habilidad de la ficha contraria durante el proximo turno."), "🧙‍♀️", 2);
            case "Chelsea Exploradora":
                return new Piece("Chelsea Exploradora", 5, new Skill("Rayo Veloz", 3, "Permite moverse el doble de la velocidad durante 1 turno, pero no se pueden usar habilidades en ese turno."), "👧", 2);
            default:
                return ShowMenu(name, selectedPiece);
        }
    }
}
