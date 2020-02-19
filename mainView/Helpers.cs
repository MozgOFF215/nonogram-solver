using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

  public class Helper
  {
    static public  Point TranslateZoomMousePosition(PictureBox pb, Point coordinates)
    {
      // test to make sure our image is not null
      if (pb.Image == null) return coordinates;
      // Make sure our control width and height are not 0 and our 
      // image width and height are not 0
      if (pb.Width == 0 || pb.Height == 0 || pb.Image.Width == 0 || pb.Image.Height == 0) return coordinates;
      // This is the one that gets a little tricky. Essentially, need to check 
      // the aspect ratio of the image to the aspect ratio of the control
      // to determine how it is being rendered
      float imageAspect = (float)pb.Image.Width / pb.Image.Height;
      float controlAspect = (float)pb.Width / pb.Height;
      float newX = coordinates.X;
      float newY = coordinates.Y;
      if (imageAspect > controlAspect)
      {
        // This means that we are limited by width, 
        // meaning the image fills up the entire control from left to right
        float ratioWidth = (float)pb.Image.Width / pb.Width;
        newX *= ratioWidth;
        float scale = (float)pb.Width / pb.Image.Width;
        float displayHeight = scale * pb.Image.Height;
        float diffHeight = pb.Height - displayHeight;
        diffHeight /= 2;
        newY -= diffHeight;
        newY /= scale;
      }
      else
      {
        // This means that we are limited by height, 
        // meaning the image fills up the entire control from top to bottom
        float ratioHeight = (float)pb.Image.Height / pb.Height;
        newY *= ratioHeight;
        float scale = (float)pb.Height / pb.Image.Height;
        float displayWidth = scale * pb.Image.Width;
        float diffWidth = pb.Width - displayWidth;
        diffWidth /= 2;
        newX -= diffWidth;
        newX /= scale;
      }
      return new Point((int)newX, (int)newY);
    }
  }
}
