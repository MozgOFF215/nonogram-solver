using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  public class DescriptorData
  {
    public int Value;
    public int rowSize;
    public int padStart;
    public int padEnd;
    public bool isSolved() => padStart + Value == rowSize - padEnd;
  }
}
