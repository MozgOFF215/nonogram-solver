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
    int _x;
    int _y;

    public Cell(int x, int y)
    {
      _x = x;
      _y = y;
    }

    public int bitmapX, bitmapY;
    public int bitmapWidth, bitmapHeight;

    public bool isTarget(int x, int y) => bitmapX < x && x < bitmapX + bitmapWidth - 1 && bitmapY < y && y < bitmapY + bitmapHeight - 1;

    public TCell Value { get { return _tCell; } }

    public void Set(TCell tCell, string key)
    {
      if (_tCell != tCell)
      {
        SolveLog.Instance.LogPA(key, _tCell, tCell, _x, _y);
        _tCell = tCell;
      }
    }

    public override string ToString()
    {
      return _tCell.ToString();
    }

    internal void Clear()
    {
      _tCell = TCell.No;
    }
  }

  class SolveArea
  {
    Cell[,] playArea;
    int sizeX, sizeY;

    public SolveArea(int sizeX, int sizeY)
    {
      playArea = new Cell[sizeX, sizeY];
      this.sizeX = sizeX;
      this.sizeY = sizeY;

      for (int y = 0; y < sizeY; y++)
        for (int x = 0; x < sizeX; x++)
          playArea[x, y] = new Cell(x, y);
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
        playArea[x, y].Set(type, key);
      }
    }

    internal void Clear()
    {
      foreach (var p in playArea) p.Clear();
    }
  }
}
