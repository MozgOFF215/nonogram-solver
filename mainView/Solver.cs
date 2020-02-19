using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  class Solver
  {
    List<List<ocrItem>> sourceData;
    int SizeX, SizeY;
    public SolveArea PlayArea;
    public List<DescriptorData>[] rowDescrV;
    public List<DescriptorData>[] rowDescrH;

    void ClearPlayArea()
    {
      PlayArea.Clear();
    }

    public void SolvePreparation(List<List<ocrItem>> sourceData)
    {
      this.sourceData = sourceData;

      var lastLine = sourceData.Skip(sourceData.Count - 2).FirstOrDefault();
      var pos = 0;

      for (int i = lastLine.Count - 1; i >= 0; i--)
      {
        if (lastLine[i].value == 0) pos = i;
        else break;
      }

      SizeX = lastLine.Count - pos;

      for (int i = sourceData.Count - 1; i >= 0; i--)
      {
        if (sourceData[i].Skip(sourceData[i].Count - 2).FirstOrDefault().value == 0) pos = i;
        else break;
      }

      SizeY = sourceData.Count - pos;

      PlayArea = new SolveArea(SizeX, SizeY);

      DescriptorsInit();
    }

    public void DescriptorsInit()
    {
      ClearPlayArea();
      rowDescrV = new List<DescriptorData>[SizeX];
      rowDescrH = new List<DescriptorData>[SizeY];

      for (int y = 0; y < sourceData.Count - SizeY; y++)
        for (int x = 0; x < SizeX; x++)
        {
          if (rowDescrV[x] == null) rowDescrV[x] = new List<DescriptorData>();
          var xx = x + sourceData[0].Count - SizeX;
          if (sourceData[y][xx].value > 0) rowDescrV[x].Add(new DescriptorData(true, x, rowDescrV[x].Count, SizeY, sourceData[y][xx].value));
        }

      for (int x = 0; x < sourceData[0].Count - SizeX; x++)
        for (int y = 0; y < SizeY; y++)
        {
          if (rowDescrH[y] == null) rowDescrH[y] = new List<DescriptorData>();
          var yy = y + sourceData.Count - SizeY;
          if (sourceData[yy][x].value > 0) rowDescrH[y].Add(new DescriptorData(false, y, rowDescrH[y].Count, SizeX, sourceData[yy][x].value));
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
          case ' ': vectorPA[indx].Set(TCell.No, "fill test"); break;
          case 'x':
          case 'X': vectorPA[indx].Set(TCell.X, "fill test"); break;
          default: vectorPA[indx].Set(TCell.F, "fill test"); break;
        }
        indx++;
      }

      rowDescrH[countTestRows] = new List<DescriptorData>();
      foreach (var d in initDescr) rowDescrH[countTestRows].Add(new DescriptorData(false, countTestRows, rowDescrH[countTestRows].Count, SizeX, d));
      countTestRows++;
    }

    void SolveLogic(int rowSize, Cell[] vectorPA, List<DescriptorData> rowDescriptors)
    {
      {
        // left to right: found limits
        var nextStart = 0;
        foreach (var d in rowDescriptors)
        {
          if (nextStart > d.PadStart) d.SetPadStart(nextStart, "left to right: found limits");
          while (!hasPlaceAtStart(d.PadStart, vectorPA, d))
          {
            d.SetPadStart(d.PadStart + 1, "left to right: found limits");
          }
          nextStart = d.PadStart + d.Value + 1;
        }
      }

      {
        // right to left: found limits
        rowDescriptors.Reverse();
        var nextEnd = 0;
        foreach (var d in rowDescriptors)
        {
          if (nextEnd > d.PadEnd) d.SetPadEnd(nextEnd, "right to left: found limits");
          while (!hasPlaceAtEnd(rowSize - d.PadEnd - 1, vectorPA, d))
          {
            d.SetPadEnd(d.PadEnd + 1, "right to left: found limits");
          }
          nextEnd = d.PadEnd + d.Value + 1;
        }
        rowDescriptors.Reverse();
      }

      // fill intersections
      foreach (var d in rowDescriptors)
      {
        var endMin = d.PadStart + d.Value - 1;
        var startMax = rowSize - d.PadEnd - d.Value;
        for (int i = startMax; i <= endMin; i++) vectorPA[i].Set(TCell.F, "fill intersections");
      }

      // left to right: fill fixed tails
      foreach (var d in rowDescriptors)
      {
        if (d.isSolved()) continue;
        var fill = false;
        var cnt = 0;
        for (int i = d.PadStart; i < d.PadStart + d.Value; i++)
        {
          if (fill) { vectorPA[i].Set(TCell.F, "left to right: fill fixed tails"); cnt++; }
          else if (vectorPA[i].Value == TCell.F) { cnt++; fill = true; }
        }
        if (cnt == d.Value) d.SetPadEnd(rowSize - (d.PadStart + d.Value), "left to right: fill fixed tails");
        break;
      }

      // right to left: fill fixed tails
      rowDescriptors.Reverse();
      foreach (var d in rowDescriptors)
      {
        if (d.isSolved()) continue;
        var fill = false;
        var cnt = 0;
        for (int i = d.PadEnd; i < d.PadEnd + d.Value; i++)
        {
          if (fill) { vectorPA[rowSize - i - 1].Set(TCell.F, "right to left: fill fixed tails"); cnt++; }
          else if (vectorPA[rowSize - i - 1].Value == TCell.F) { cnt++; fill = true; }
        }
        if (cnt == d.Value) d.SetPadStart(rowSize - (d.PadEnd + d.Value), "right to left: fill fixed tails");
        break;
      }
      rowDescriptors.Reverse();

      {
        // left to right: mark imposible cells as X
        var current = 0;
        foreach (var d in rowDescriptors)
        {
          for (int i = current; i < d.PadStart; i++) vectorPA[i].Set(TCell.X, "left to right: mark imposible cells as X");
          current = rowSize - d.PadEnd;
        }
      }

      {
        // right to left: mark imposible cells as X
        rowDescriptors.Reverse();
        var current = 0;
        foreach (var d in rowDescriptors)
        {
          for (int i = current; i < d.PadEnd; i++) vectorPA[rowSize - i - 1].Set(TCell.X, "right to left: mark imposible cells as X");
          current = rowSize - d.PadStart;
        }
        rowDescriptors.Reverse();
      }
    }

  }

}
