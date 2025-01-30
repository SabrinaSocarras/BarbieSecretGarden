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
               .AddColumn(new TableColumn("[bold]Piece[/]").Centered())
               .AddColumn(new TableColumn("[bold]Ability[/]").Centered())
               .AddColumn(new TableColumn("[bold]Description[/]").Centered());	

        table.AddRow("Barbie Star", "Star Glow", "Allows jumping over an obstacle or trap.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Ken Adventurer", "Protective Shield", "Allows movement in a 5-cell straight line radius.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Skipper Inventor", "Reversible Drone", "Converts a trap into an extra turn.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Stacie Detective", "Crystal Spell", "Teleports randomly to another cell.");
        table.AddRow(new Rule(), new Rule(), new Rule());
        table.AddRow("Chelsea Explorer", "Speed Ray", "Allows double speed movement for 1 turn.");

        AnsiConsole.Write(table);
        Console.WriteLine("");
        // Menu options
        List<string> choices = new List<string>() { "Barbie Star", "Ken Adventurer", "Skipper Inventor", "Stacie Detective", "Chelsea Explorer" };
        foreach (var piece in selectedPiece)
        {
            choices.Remove(piece.Name);
        }
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title($"{name}, Select a piece to play:")
            .AddChoices(choices.ToArray()));

        AnsiConsole.MarkupLine($"{name} has selected: [bold]{option}[/]");

        // Handle selected options
        switch (option)
        {
            case "Barbie Star":
                return new Piece("Barbie Star", 10, new StarGlow(), "👩");
            case "Ken Adventurer":
                return new Piece("Ken Adventurer", 3, new ProtectiveShield(),"👨");
            case "Skipper Inventor":
                 return new Piece("Skipper Inventor", 2, new ReversibleDrone(), "👩‍🔧");
            case "Stacie Detective":    
                return new Piece("Stacie Detective", 10, new CrystalSpell(), "👩");
            case "Chelsea Explorer":
                return new Piece("Chelsea Explorer", 5, new SpeedRay(),"👧");
            default:
                return ShowMenu(name, selectedPiece);
        }
    }
}
