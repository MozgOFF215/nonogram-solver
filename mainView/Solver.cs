using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  class Solver
  {
    List<List<int>> sourceData;
    int SizeX, SizeY;
    public SolveArea PlayArea;
    public List<DescriptorData>[] rowDescrV;
    public List<DescriptorData>[] rowDescrH;

    void ClearPlayArea()
    {
      PlayArea = new SolveArea(new Cell[SizeX, SizeY], SizeX, SizeY);
    }

    public void SolvePreparation(List<List<int>> sourceData)
    {
      this.sourceData = sourceData;

      var lastLine = sourceData.Skip(sourceData.Count - 2).FirstOrDefault();
      var pos = 0;

      for (int i = lastLine.Count - 1; i >= 0; i--)
      {
        if (lastLine[i] == 0) pos = i;
        else break;
      }

      SizeX = lastLine.Count - pos;

      for (int i = sourceData.Count - 1; i >= 0; i--)
      {
        if (sourceData[i].Skip(sourceData[i].Count - 2).FirstOrDefault() == 0) pos = i;
        else break;
      }

      SizeY = sourceData.Count - pos;

      PlayAreaInit();
    }

    public void PlayAreaInit()
    {
      ClearPlayArea();

      rowDescrV = new List<DescriptorData>[SizeX];
      rowDescrH = new List<DescriptorData>[SizeY];

      for (int y = 0; y < sourceData.Count - SizeY; y++)
        for (int x = 0; x < SizeX; x++)
        {
          if (rowDescrV[x] == null) rowDescrV[x] = new List<DescriptorData>();
          var xx = x + sourceData[0].Count - SizeX;
          if (sourceData[y][xx] > 0) rowDescrV[x].Add(new DescriptorData
          {
            Value = sourceData[y][xx]
          });
        }

      for (int x = 0; x < sourceData[0].Count - SizeX; x++)
        for (int y = 0; y < SizeY; y++)
        {
          if (rowDescrH[y] == null) rowDescrH[y] = new List<DescriptorData>();
          var yy = y + sourceData.Count - SizeY;
          if (sourceData[yy][x] > 0) rowDescrH[y].Add(new DescriptorData { Value = sourceData[yy][x] });
        }

    }

    public void SolveHorizStep()
    {
      SolveStep(SizeX, SizeY, GetPAVectorHoriz, rowDescrH, FillAndMarkSideAsX_Horiz);
    }

    public void SolveVertStep()
    {
      SolveStep(SizeY, SizeX, GetPAVectorVert, rowDescrV, FillAndMarkSideAsX_Vert);
    }

    Cell[] GetPAVectorHoriz(int row)
    {
      var res = new List<Cell>();
      for (int d = 0; d < SizeX; d++) res.Add(PlayArea.GetCell(d, row));
      return res.ToArray();
    }

    Cell[] GetPAVectorVert(int col)
    {
      var res = new List<Cell>();
      for (int d = 0; d < SizeY; d++) res.Add(PlayArea.GetCell(col, d));
      return res.ToArray();
    }

    bool hasPlaceAtStart(int pos, Cell[] vector, DescriptorData descriptor)
    {
      var posBefore = pos - 1;
      if (posBefore >= 0 && vector[posBefore].Value == TCell.F) return false;

      for (int d = pos; d < pos + descriptor.Value; d++)
        if (vector[d].Value == TCell.X) return false;

      var posAfter = pos + descriptor.Value;
      if (posAfter < vector.Length && vector[posAfter].Value == TCell.F) return false;

      return true;
    }

    bool hasPlaceAtEnd(int pos, Cell[] vector, DescriptorData descriptor)
    {
      var posBefore = pos + 1;
      if (posBefore < vector.Length && vector[posBefore].Value == TCell.F) return false;

      for (int d = pos; d > pos - descriptor.Value; d--)
        if (vector[d].Value == TCell.X) return false;

      var posAfter = pos - descriptor.Value;
      if (posAfter >= 0 && vector[posAfter].Value == TCell.F) return false;

      return true;
    }

    bool isFilled(int x1, int y1, int x2, int y2)
    {
      for (int x = x1; x <= x2; x++)
        for (int y = y1; y <= y2; y++)
          if (PlayArea.GetValue(x, y) != TCell.F) return false;
      return true;
    }

    void markSideAsXHoriz(int x1, int x2, int y)
    {
      var left = x1 - 1;
      var right = x2 + 1;
      if (left >= 0) PlayArea.SetCell(left, y, TCell.X, "markSideAsXHoriz left >= 0");
      if (right < SizeX) PlayArea.SetCell(right, y, TCell.X, "markSideAsXHoriz right < SizeX");
    }

    void markSideAsXVert(int y1, int y2, int x)
    {
      var up = y1 - 1;
      var down = y2 + 1;
      if (up >= 0) PlayArea.SetCell(x, up, TCell.X, "markSideAsXVert up >= 0");
      if (down < SizeY) PlayArea.SetCell(x, down, TCell.X, "markSideAsXVert down < SizeY");
    }

    bool FillAndMarkSideAsX_Horiz(int start, int end, int y)
    {
      bool solved = isFilled(start, y, end, y);
      if (solved) markSideAsXHoriz(start, end, y);
      return solved;
    }

    bool FillAndMarkSideAsX_Vert(int start, int end, int x)
    {
      bool solved = isFilled(x, start, x, end);
      if (solved) markSideAsXVert(start, end, x);
      return solved;
    }

    void SolveStep(int rowSize, int amountRow, Func<int, Cell[]> GetPAVector, List<DescriptorData>[] rowDescriptors, Func<int, int, int, bool> FillAndMarkSideAsX)
    {
      for (int y = 0; y < amountRow; y++)
      {
        SolveLogic(rowSize, GetPAVector(y), rowDescriptors[y]);
      }
    }

    public void SolveSmallStepH(int row)
    {
      SolveLogic(SizeX, GetPAVectorHoriz(row), rowDescrH[row]);
    }

    public void SolveSmallStepV(int col)
    {
      SolveLogic(SizeY, GetPAVectorVert(col), rowDescrV[col]);
    }

    public void SolveTestInit()
    {
      countTestRows = 0;
      //             01234567890123456789
      _fillTestData("  b  b   b          ", new int[] { 4, 2, 9 });
      _fillTestData("                    ", new int[] { 4, 2, 9 });
      _fillTestData("   x  x             ", new int[] { 3, 2, 8 });
      _fillTestData("   xb xb            ", new int[] { 3, 2, 8 });

    }

    public void SolveTestGo()
    {
      for (var i = 0; i < countTestRows; i++)
        SolveLogic(SizeX, GetPAVectorHoriz(i), rowDescrH[i]);
    }

    int countTestRows;

    void _fillTestData(string initPA, int[] initDescr)
    {
      var vectorPA = GetPAVectorHoriz(countTestRows);
      int indx = 0;
      foreach (var c in initPA)
      {
        switch (c)
        {
          case ' ': vectorPA[indx].Set(TCell.No); break;
          case 'x':
          case 'X': vectorPA[indx].Set(TCell.X); break;
          default: vectorPA[indx].Set(TCell.F); break;
        }
        indx++;
      }

      rowDescrH[countTestRows] = new List<DescriptorData>();
      foreach (var d in initDescr) rowDescrH[countTestRows].Add(new DescriptorData { Value = d });
      countTestRows++;
    }


    void initSizeDescriptors()
    {
      foreach (var r in rowDescrH) foreach (var d in r) d.rowSize = SizeX;
      foreach (var r in rowDescrV) foreach (var d in r) d.rowSize = SizeY;
    }

    void SolveLogic(int rowSize, Cell[] vectorPA, List<DescriptorData> rowDescriptors)
    {
      initSizeDescriptors();

      {
        // left to right: found limits
        var nextStart = 0;
        foreach (var d in rowDescriptors)
        {
          if (nextStart > d.padStart) d.padStart = nextStart;
          while (!hasPlaceAtStart(d.padStart, vectorPA, d))
          {
            d.padStart++;
          }
          nextStart = d.padStart + d.Value + 1;
        }
      }

      {
        // right to left: found limits
        rowDescriptors.Reverse();
        var nextEnd = 0;
        foreach (var d in rowDescriptors)
        {
          if (nextEnd > d.padEnd) d.padEnd = nextEnd;
          while (!hasPlaceAtEnd(rowSize - d.padEnd - 1, vectorPA, d))
          {
            d.padEnd++;
          }
          nextEnd = d.padEnd + d.Value + 1;
        }
        rowDescriptors.Reverse();
      }

      // fill intersections
      foreach (var d in rowDescriptors)
      {
        var endMin = d.padStart + d.Value - 1;
        var startMax = rowSize - d.padEnd - d.Value;
        for (int i = startMax; i <= endMin; i++) vectorPA[i].Set(TCell.F);
      }

      // left to right: fill fixed tails
      foreach (var d in rowDescriptors)
      {
        if (d.isSolved()) continue;
        var fill = false;
        var cnt = 0;
        for (int i = d.padStart; i < d.padStart + d.Value; i++)
        {
          if (fill) { vectorPA[i].Set(TCell.F); cnt++; }
          else if (vectorPA[i].Value == TCell.F) { cnt++; fill = true; }
        }
        if (cnt == d.Value) d.padEnd = rowSize - (d.padStart + d.Value);
        break;
      }

      // right to left: fill fixed tails
      rowDescriptors.Reverse();
      foreach (var d in rowDescriptors)
      {
        if (d.isSolved()) continue;
        var fill = false;
        var cnt = 0;
        for (int i = d.padEnd; i < d.padEnd + d.Value; i++)
        {
          if (fill) { vectorPA[rowSize - i - 1].Set(TCell.F); cnt++; }
          else if (vectorPA[rowSize - i - 1].Value == TCell.F) { cnt++; fill = true; }
        }
        if (cnt == d.Value) d.padStart = rowSize - (d.padEnd + d.Value);
        break;
      }
      rowDescriptors.Reverse();

      {
        // left to right: mark imposible cells as X
        var current = 0;
        foreach (var d in rowDescriptors)
        {
          for (int i = current; i < d.padStart; i++) vectorPA[i].Set(TCell.X);
          current = rowSize - d.padEnd;
        }
      }

      {
        // right to left: mark imposible cells as X
        rowDescriptors.Reverse();
        var current = 0;
        foreach (var d in rowDescriptors)
        {
          for (int i = current; i < d.padEnd; i++) vectorPA[rowSize - i - 1].Set(TCell.X);
          current = rowSize - d.padStart;
        }
        rowDescriptors.Reverse();
      }
    }

  }

}
