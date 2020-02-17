using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  class AverageWithWindow
  {
    int windowSize;
    Queue<int> queue;
    public AverageWithWindow(int windowSize)
    {
      this.windowSize = windowSize;
      queue = new Queue<int>();
    }

    public double NewValue(int newValue)
    {
      queue.Enqueue(newValue);
      while (queue.Count > windowSize)
        queue.Dequeue();

     return queue.Average();
    }
  }
}
