using Spectre.Console;
using System.Threading;

namespace BarbieSecretGarden;

public class ReversibleDrone : Skill
{
    public ReversibleDrone()
    {
        Type = SkillType.ReversibleDrone;
        Description = "The cureent players can convert a trap into a path and continue playing.";
        Cooldown = 2;
    }
   
        public override void Execute(Game game)
    {
        int playerX = game.CurrenPlayer.Piece.X;
        int playerY = game.CurrenPlayer.Piece.Y;
        FindNearestTrap(game, playerX, playerY);
    }

    private void FindNearestTrap(Game game, int playerX, int playerY)
    {
        (int X, int Y)? nearestTrap = null;
        double minDistance = double.MaxValue;

        for (int x = 0; x < game.Board.Size; x++)
        {
            for (int y = 0; y < game.Board.Size; y++)
            {
                if (game.Board.Cells[x, y].Type == CellType.ReturnToStart || game.Board.Cells[x, y].Type == CellType.StayInPlace || game.Board.Cells[x, y].Type == CellType.SpeedReduction)
                {
                    double distance = Math.Sqrt(Math.Pow(x - playerX, 2) + Math.Pow(y - playerY, 2));

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestTrap = (x, y);
                    }
                }
            }
        }
        
        if(nearestTrap == null)
        {
            AnsiConsole.Markup("There is not any tramp near.");
            return ;
        }
        
       game.Board.Cells[nearestTrap.Value.X, nearestTrap.Value.Y].Type = CellType.Path;
    }
}