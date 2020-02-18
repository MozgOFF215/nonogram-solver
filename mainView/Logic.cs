using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Tesseract;

namespace mainView
{
  class ocrItem
  {
    public int x, y; // in table SolveArea
    public bool isDescriptor;
    public bool hasNumber;
    public int bitmapX, bitmapY, width, height;
    public int value;
  }

  class Logic
  {
    static public List<MarkedLineInfo> SearchLines(int numberOfLines, int lineSize, int level, Func<int, int, int> getColor)
    {
      var markedLines = new List<MarkedLineInfo>();
      var lastYwithMarkedLine = -10;
      var lineCounter = 0;
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
            markedLines.Add(new MarkedLineInfo { lineInfos = new List<LineInfo> { lineWithMaxLength }, start = y, length = 1, number = lineCounter++ });

          lastYwithMarkedLine = y;
        }
      }

      return markedLines;
    }

    static public List<List<ocrItem>> OCR(List<MarkedLineInfo> markedLinesX, List<MarkedLineInfo> markedLinesY, Func<int, int, Color> getPixel)
    {
      int descrXwidth, descrYheight;
      SearchDataBounds(markedLinesX, markedLinesY, out descrXwidth, out descrYheight);

      var res = new List<List<ocrItem>>();
      var fullWidthResultSprite = 0;
      var maxHeightResultSprite = 0;
      var maxWidthResultSprite = 0;
      var fullHeightResultSprite = 0;
      for (int iy = 0; iy < markedLinesY.Count - 1; iy++)
      {
        var resX = new List<ocrItem>();
        for (int ix = 0; ix < markedLinesX.Count - 1; ix++)
        {
          var newDescriptor = new ocrItem { x = ix, y = iy };
          if ((ix < descrXwidth && iy >= descrYheight) || (iy < descrYheight && ix >= descrXwidth))
          {
            newDescriptor.isDescriptor = true;

            var widthX = markedLinesX[ix + 1].start - markedLinesX[ix].after;
            var widthY = markedLinesY[iy + 1].start - markedLinesY[iy].after;

            newDescriptor.bitmapX = markedLinesX[ix].after;
            newDescriptor.bitmapY = markedLinesY[iy].after;

            newDescriptor.width = widthX;
            newDescriptor.height = widthY;

            fullWidthResultSprite += widthX;
            maxHeightResultSprite = widthY > maxHeightResultSprite ? widthY : maxHeightResultSprite;

            fullHeightResultSprite += widthY;
            maxWidthResultSprite = widthX > maxWidthResultSprite ? widthX : maxWidthResultSprite;

            long fullnessI = 0;

            for (int y = 0; y < widthY; y++)
              for (int x = 0; x < widthX; x++)
              {
                var pixColor = getPixel(x + markedLinesX[ix].after, y + markedLinesY[iy].after);

                fullnessI += 255 - pixColor.R;
              }

            var fullness = fullnessI / widthY / widthX;
            if (fullness > 10) newDescriptor.hasNumber = true;
          }
          resX.Add(newDescriptor);
        }
        res.Add(resX);
      }

      var fullBmpH = new Bitmap(fullWidthResultSprite, maxHeightResultSprite);
      var fullBmpV = new Bitmap(maxWidthResultSprite, fullHeightResultSprite);
      var grH = Graphics.FromImage(fullBmpH);
      var grV = Graphics.FromImage(fullBmpV);

      var currentX = 0;
      var currentY = 0;
      foreach (var line in res)
        foreach (var cell in line)
        {
          if (cell.isDescriptor && cell.hasNumber)
          {
            var bSprite = new Bitmap(cell.width, cell.height);
            long fullnessI = 0;

            for (int y = 0; y < cell.height; y++)
              for (int x = 0; x < cell.width; x++)
              {
                var pixColor = getPixel(x + cell.bitmapX, y + cell.bitmapY);

                if (x == 0 || y == 0 || y == cell.height - 1 || x == cell.width - 1)
                  pixColor = Color.White;

                if (pixColor.R > 192) pixColor = Color.White;
                else pixColor = Color.Black;

                fullnessI += 255 - pixColor.R;
                bSprite.SetPixel(x, y, pixColor);
              }

            var fullness = fullnessI / cell.height / cell.width;
            if (fullness < 10) continue;

            var resV2 = OCRBitmapV2(bSprite);
            var resV3 = OCRBitmapV3(bSprite);

            var value = 0;
            if (resV2.Item1 == "~")
            {
              value = 8;
              //value = string.IsNullOrWhiteSpace(resV3.Item1) ? resV2.Item2 : Int32.Parse(resV3.Item1);
            }
            else
            {
              value = resV2.Item2;
              var val2 = string.IsNullOrWhiteSpace(resV3.Item1) ? value : Int32.Parse(resV3.Item1);
              if (value != val2)
              {

              }
            }

            cell.value = value;

            SaveOCRResult(cell, resV2, resV3, bSprite);

            grH.DrawImage(bSprite, currentX, 0);
            currentX += cell.width;

            grV.DrawImage(bSprite, 0, currentY);
            currentY += cell.height;

          }
        }

      return res;
    }

    const string ocrResultsPath = @"./ocr-results";
    const string ocrReportName = "ocr-report.csv";

    public static void InitOCRResultSaver()
    {
      if (!Directory.Exists(ocrResultsPath)) Directory.CreateDirectory(@ocrResultsPath);
      else foreach (var file in new DirectoryInfo(ocrResultsPath).GetFiles()) file.Delete();

      return;
      using (var file = new StreamWriter($"{ocrResultsPath}/{ocrReportName}"))
      {
        file.WriteLine($"x;y;v2 text;v2 value;v3 text;v3 block;v3 exception");
      }
    }

    private static void SaveOCRResult(ocrItem cell, Tuple<string, int> resV2, Tuple<string, string, string> resV3, Bitmap bSprite)
    {
      return;
      var prefixName = $"{cell.x:00}-{cell.y:00}";
      bSprite.Save($"{ocrResultsPath}/{prefixName}.png", System.Drawing.Imaging.ImageFormat.Png);

      using (var file = new StreamWriter($"{ocrResultsPath}/{ocrReportName}", true))
      {
        file.WriteLine($"{cell.x:00};{cell.y:00};{resV2.Item1};{resV2.Item2};{resV3.Item1};{""};{(resV3.Item3 != null ? "excepted" : "")}");
      }
    }

    static Tuple<string, int> OCRBitmapV2(Bitmap bSprite)
    {
      tessnet2.Tesseract ocr = new tessnet2.Tesseract();
      //ocr.Init(@"./tessdata2", "en", true);
      ocr.SetVariable("tessedit_char_whitelist", "0123456789B");
      ocr.Init(@"", "eng", false);
      List<tessnet2.Word> result = ocr.DoOCR(bSprite, Rectangle.Empty);
      var resultText = string.Join("", result.Select(i => i.Text));
      var resultValue = -101;
      if (int.TryParse(resultText, out resultValue)) { }
      //  bSprite.Save($".\\digitals\\{string.Join("", result.Select(i => i.Text.Replace("|", "I")))} {string.Join("_", result.Select(i => i.Confidence))} {ix:00}-{iy:00}.png", ImageFormat.Png);
      //else
      //  bSprite.Save($".\\digitals\\unknown {ix:00}-{iy:00}.png", ImageFormat.Png);

      return new Tuple<string, int>(resultText, resultValue);
    }

    static Tuple<string, string, string> OCRBitmapV3(Bitmap fullBmp)
    {
      string textResult = null;
      string blocksResult = null;
      string exceptionString = null;

      return new Tuple<string, string, string>(textResult, blocksResult, exceptionString);

      try
      {
        using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
        {
          engine.SetVariable("tessedit_char_whitelist", "0123456789B");
          using (var page = engine.Process(fullBmp))
          {

            textResult = page.GetText();

            blocksResult = "";
            using (var iter = page.GetIterator())
            {
              iter.Begin();
              do
              {
                do
                {
                  do
                  {
                    do
                    {
                      if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                      {
                        blocksResult += ConsoleWriteLine("<BLOCK>");
                      }

                      blocksResult += ConsoleWrite(iter.GetText(PageIteratorLevel.Word));
                      blocksResult += ConsoleWrite("_");

                      if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                      {
                        blocksResult += ConsoleWriteLine("%");
                      }
                    } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                    if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                    {
                      blocksResult += ConsoleWriteLine("§");
                    }
                  } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
              } while (iter.Next(PageIteratorLevel.Block));
            }

            //if (int.TryParse(text, out newDescriptor.value))
            //  fullBmp.Save($"{ocrResultsPath}/{newDescriptor.value} {ix:00}-{iy:00}.png", System.Drawing.Imaging.ImageFormat.Png);
            //else
            //fullBmp.Save($"{ocrResultsPath}/full bmp.png", System.Drawing.Imaging.ImageFormat.Png);
          }
        }
      }
      catch (Exception e)
      {
        exceptionString = e.ToString();
      }
      return new Tuple<string, string, string>(textResult, blocksResult, exceptionString);
    }

    private static string ConsoleWrite(string v)
    {
      return v;
    }

    private static string ConsoleWriteLine(string v)
    {
      return v + Environment.NewLine;
    }

    internal static void SearchDataBounds(List<MarkedLineInfo> markedLinesX, List<MarkedLineInfo> markedLinesY, out int descrXwidth, out int descrYheight)
    {
      descrXwidth = markedLinesX.Where(i => i.lineInfos.OrderByDescending(j => j.length).First().start > 50).Count() + 1;
      descrYheight = markedLinesY.Where(i => i.lineInfos.OrderByDescending(j => j.length).First().start > 50).Count() + 1;
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
