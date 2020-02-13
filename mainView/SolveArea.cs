using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  public enum TCell { No = 0, X = 1, F = 2 }
  public class Cell
  {
    TCell _tCell;
    public TCell Value { get { return _tCell; } }

    public void Set(TCell tCell)
    {
      _tCell = tCell;
    }

    public override string ToString()
    {
      return _tCell.ToString();
    }
  }

  class SolveArea
  {
    Cell[,] playArea;
    List<SolveLog> solveLog = new List<SolveLog>();
    int sizeX, sizeY;
    public SolveArea(Cell[,] playArea, int sizeX, int sizeY)
    {
      this.playArea = playArea;
      this.sizeX = sizeX;
      this.sizeY = sizeY;
      for (int y = 0; y < sizeY; y++) for (int x = 0; x < sizeX; x++) playArea[x, y] = new Cell();
    }
    public int SizeX { get { return sizeX; } }
    public int SizeY { get { return sizeY; } }
    public Cell GetCell(int x, int y) => playArea[x, y];
    public TCell GetValue(int x, int y) => playArea[x, y].Value;
    public void SetCell(int x, int y, TCell type, string key)
    {
      var current = playArea[x, y];
      if (current.Value != type)
      {
        playArea[x, y].Set(type);
        solveLog.Add(new SolveLog { key = key, old = current.Value, @new = type, x = x, y = y });
      }
    }
  }
}
