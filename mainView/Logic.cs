using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace mainView
{
  class Logic
  {
    static int counter = 0;
    static public List<MarkedLineInfo> SearchLines(int numberOfLines, int lineSize, int level, Func<int, int, int> getColor)
    {
      counter++;
      var markedLines = new List<MarkedLineInfo>();
      var lastYwithMarkedLine = -10;
      for (int y = 0; y < numberOfLines; y++)
      {
        var lines = new List<LineInfo>();
        var prevVal = 0d;
        var currentLen = 0;
        var startX = 0;
        for (int x = 0; x < lineSize; x++)
        {
          var val = getColor(x, y);
          if (val < level)
          {
            if (prevVal < level)
              currentLen++;
            else
            {
              currentLen = 1;
              startX = x;
            }
          }
          else if (prevVal < level)
          {
            if (currentLen > 10)
            {
              lines.Add(new LineInfo { start = startX, end = x, length = currentLen });
              currentLen = 0;
            }
          }
          prevVal = val;
        }

        //if (currentLen > 10)
        //  lines.Add(new LineInfo { start = startX, end = startX + currentLen, length = currentLen });

        var lineWithMaxLength = lines.OrderByDescending(i => i.length).FirstOrDefault();
        var max1 = lineWithMaxLength?.length ?? 0;
        var maxLength = max1 / (double)lineSize;

        if (maxLength >= 0.5)
        {
          if (lastYwithMarkedLine + 1 == y)
          {
            markedLines.Last().length++;
            markedLines.Last().lineInfos.Add(lineWithMaxLength);
          }
          else
            markedLines.Add(new MarkedLineInfo { lineInfos = new List<LineInfo> { lineWithMaxLength }, start = y, length = 1 });

          lastYwithMarkedLine = y;
        }
      }

      return markedLines;
    }

    static public List<List<int>> OCR(List<MarkedLineInfo> markedLinesX, List<MarkedLineInfo> markedLinesY, Func<int, int, Color> getPixel)
    {
      var res = new List<List<int>>();
      for (int iy = 0; iy < markedLinesY.Count - 1; iy++)
      {
        var resX = new List<int>();
        for (int ix = 0; ix < markedLinesX.Count - 1; ix++)
        {
          var widthX = markedLinesX[ix + 1].start - markedLinesX[ix].after;
          var widthY = markedLinesY[iy + 1].start - markedLinesY[iy].after;
          var bSprite = new Bitmap(widthX, widthY);

          long fullnessI = 0;

          for (int y = 0; y < widthY; y++)
            for (int x = 0; x < widthX; x++)
            {
              //var pixColor = GrayscaledSourceBitmap.GetPixel(validCellsX[ix].posAfterFront + x, validCellsY[iy].posAfterFront + y);
              var pixColor = getPixel(x + markedLinesX[ix].after, y + markedLinesY[iy].after);

              if (x == 0 || y == 0 || y == widthY - 1 || x == widthX - 1)
                pixColor = Color.White;

              if (pixColor.R > 192) pixColor = Color.White;
              //else pixColor = Color.Black;

              bSprite.SetPixel(x, y, pixColor);
              fullnessI += 255 - pixColor.R;
            }
          var fullness = fullnessI / widthY / widthX;
          var value = 0;
          if (fullness > 10)
          {
            try
            {
              tessnet2.Tesseract ocr = new tessnet2.Tesseract();
              ocr.SetVariable("tessedit_char_whitelist", "0123456789");
              ocr.Init(@"", "eng", false);
              List<tessnet2.Word> result = ocr.DoOCR(bSprite, Rectangle.Empty);
              if (int.TryParse(string.Join("", result.Select(i => i.Text)), out value))
                bSprite.Save($".\\digitals\\{string.Join("", result.Select(i => i.Text.Replace("|", "I")))} {string.Join("_", result.Select(i => i.Confidence))} {ix:00}-{iy:00}.png", ImageFormat.Png);
              else
                bSprite.Save($".\\digitals\\unknown {ix:00}-{iy:00}.png", ImageFormat.Png);
            }
            catch (Exception e)
            {
            }
          }
          resX.Add(value);
        }
        res.Add(resX);
      }

      return res;
    }

    internal static Bitmap Crop(Bitmap bitmap, int startY, int heightY)
    {
      var r = new Rectangle(0, startY, bitmap.Width, heightY);
      Bitmap nb = new Bitmap(r.Width, r.Height);
      Graphics g = Graphics.FromImage(nb);
      g.DrawImage(bitmap, -r.X, -r.Y);
      return nb;
    }

    public static Dictionary<int, int> GenHistogram(int numberOfLines, int lineSize, Func<int, int, int> getPixel)
    {
      var resHist = new Dictionary<int, int>();
      double prev = 0;
      for (int y = 0; y < numberOfLines; y++)
      {
        long hist = 0;
        for (int x = 0; x < lineSize; x++)
        {
          hist += getPixel(x, y);
        }
        var res = hist / (double)lineSize;
        resHist[y] = (int)res;
        prev = res;
      }

      return resHist;
    }

    public static void RefreshHistX(long level, Dictionary<int, int> histDictionary, Bitmap resultBitmap, List<MarkedLineInfo> markedLines, int maxValX)
    {
      foreach (var hist in histDictionary)
      {
        for (int i = 0; i < resultBitmap.Height; i++)
        {
          if (i < 10)
          {
            if (i < 5)
            {
              var hasMarkedLine = markedLines.Where(j => j.start <= hist.Key && j.start + j.length >= hist.Key).Count() > 0;
              resultBitmap.SetPixel(hist.Key, i, hasMarkedLine ? Color.Red : Color.Green);
            }
            else
            {
              if (hist.Value < level)
              {
                resultBitmap.SetPixel(hist.Key, i, Color.White);
              }
              else
              {
                resultBitmap.SetPixel(hist.Key, i, Color.Blue);
              }
            }
          }
          else
          {
            if ((i - 10) < hist.Value * (resultBitmap.Height - 10) / maxValX)
              resultBitmap.SetPixel(hist.Key, i, Color.Gray);
            else
              resultBitmap.SetPixel(hist.Key, i, Color.White);
          }
        }
      }
    }

    public static void RefreshHistY(long level, Dictionary<int, int> histDictionary, Bitmap resultBitmap, List<MarkedLineInfo> markedLines, int maxValY)
    {
      foreach (var hist in histDictionary)
      {
        for (int i = 0; i < resultBitmap.Width; i++)
        {
          if (i < 10)
          {
            if (i < 5)
            {
              var hasMarkedLine = markedLines.Where(j => j.start <= hist.Key && j.start + j.length >= hist.Key).Count() > 0;
              resultBitmap.SetPixel(i, hist.Key, hasMarkedLine ? Color.Red : Color.Green);
            }
            else
            {
              if (hist.Value < level)
              {
                resultBitmap.SetPixel(i, hist.Key, Color.White);
              }
              else
              {
                resultBitmap.SetPixel(i, hist.Key, Color.Blue);
              }
            }
          }
          else
          {
            if ((i - 10) < hist.Value * (resultBitmap.Width - 10) / maxValY)
              resultBitmap.SetPixel(i, hist.Key, Color.Gray);
            else resultBitmap.SetPixel(i, hist.Key, Color.White);

          }
        }
      }
    }

  }
}
