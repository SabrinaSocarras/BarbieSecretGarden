using System.Transactions;

namespace BarbieSecretGarden;

public class CrystalSpell : Skill
{
  public CrystalSpell()
  {
    Name = "Crystal Spell";
    Type = SkillType.CrystalSpell;
    Description = "The current player can teleport randomly to another cell.";
  }
  public override void Execute(Game game)
  {
    Random rand = new Random();
    int x = rand.Next(0, game.Board.Size);
    int y = rand.Next(0, game.Board.Size);
    while (game.Board.Cells[x, y].Type == CellType.Wall || game.Board.Cells[x, y].Type == CellType.Start || game.Board.Cells[x, y].Type == CellType.Final || game.Board.Cells[x, y].Type == CellType.SpeedReduction || game.Board.Cells[x, y].Type == CellType.ReturnToStart || game.Board.Cells[x, y].Type == CellType.StayInPlace)
    {
      x = rand.Next(0, game.Board.Size);
      y = rand.Next(0, game.Board.Size);
    }
    game.CurrenPlayer.Piece.X = x;
    game.CurrenPlayer.Piece.Y = y;
  }

}