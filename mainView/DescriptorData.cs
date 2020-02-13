using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  public class DescriptorData
  {
    int rowSize;
    int padStart;
    int padEnd;
    bool isVertical;
    int row;
    int position;
    int value;

    public DescriptorData(bool isVertical, int row, int position, int rowSize, int value)
    {
      this.isVertical = isVertical;
      this.row = row;
      this.position = position;
      this.rowSize = rowSize;
      this.value = value;
    }

    //public int RowSize { get { return rowSize; } }
    public int Value { get { return value; } }
    public int PadStart { get { return padStart; } }  
    public int PadEnd { get { return padEnd; } }

    public void SetPadStart(int padStart, string key)
    {
      if (this.padStart != padStart) SolveLog.Instance.LogDPadStart(key, this.padStart, padStart);
      this.padStart = padStart;
    }

    public void SetPadEnd(int padEnd, string key)
    {
      if (this.padEnd != padEnd) SolveLog.Instance.LogDPadEnd(key, this.padEnd , padEnd);
      this.padEnd = padEnd;
    }

    public bool isSolved() => padStart + value == rowSize - padEnd;
  }
}
