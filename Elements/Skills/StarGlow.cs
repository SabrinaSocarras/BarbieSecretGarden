using Spectre.Console;

namespace BarbieSecretGarden;

public class StarGlow : Skill
{
    public StarGlow()
    {
        Name = "Star Glow";
        Type = SkillType.StarGlow;
        Description = "Allows jumping over obstacles or traps, moving up to 2 additional cells";
    }
    public override void Execute(Game game)
    {
        var prompt = new SelectionPrompt<string>()
            .Title("Select direction")
            .AddChoices(new[] { "up", "down", "left", "right" });

        string direction = AnsiConsole.Prompt(prompt);

        int x = game.CurrenPlayer.Piece.X;
        int y = game.CurrenPlayer.Piece.Y;
        switch (direction)
        {
            case "up":
                for (int i = 1; i <= 2; i++)
                {
                    if (x - i >= 0)
                    {
                        game.CurrenPlayer.Piece.X = x - i;
                    }
                }
                break;
            case "down":
                for (int i = 1; i <= 2; i++)
                {
                    if (x + i < game.Board.Size)
                    {
                        game.CurrenPlayer.Piece.X = x + i;
                    }
                }
                break;
            case "left":
                for (int i = 1; i <= 2; i++)
                {
                    if (y - i >= 0)
                    {
                        game.CurrenPlayer.Piece.Y = y - i;
                    }
                }
                break;
            case "right":
                for (int i = 1; i <= 2; i++)
                {
                    if (y + i < game.Board.Size)
                    {
                        game.CurrenPlayer.Piece.Y = y + i;
                    }
                }
                break;
            default:
                AnsiConsole.Markup("[red]Invalid direction selected.[/]");
                break;
                //falta que
        }
    }
}