using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  class LineInfo
  {
    public int start;
    public int end;
    public int length;
  }

  class MarkedLineInfo
  {
    public List<LineInfo> lineInfos;
    public int start;
    public int length;
    public int after => start + length;
  }
}
