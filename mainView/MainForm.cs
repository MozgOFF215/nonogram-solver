using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace mainView
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    Solver _Solve = new Solver();

    Dictionary<int, long> histX;
    Dictionary<int, long> histY;
    Dictionary<int, bool> histXboolean;
    Dictionary<int, bool> histYboolean;

    List<SourceCell> cellsX;
    List<SourceCell> cellsY;

    Bitmap SourceBitmap;
    Bitmap GrayscaledSourceBitmap;
    Bitmap HistBitmapX;
    Bitmap HistBitmapY;
    long maxValX;
    long maxValY;
    int levelX, levelY;

    class SourceCell
    {
      public int front;
      public int posAfterFront;
      public int width;
      public int back;
      public int number;
    }

    void MainForm_Load(object sender, EventArgs e)
    {
      //Image SourceImage = Image.FromFile("..\\..\\..\\..\\Japan_Screenshots\\Screenshot_10x10_2.png");
      Image SourceImage = Image.FromFile("..\\..\\..\\..\\Japan_Screenshots\\Screenshot_20x20.png");
      SourceBitmap = new Bitmap(SourceImage);

      GrayscaledSourceBitmap = BitmapUtils.MakeGrayscale3(new Bitmap(SourceImage));

      pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBoxOriginal.Image = SourceImage;

      Image Grayscaled = GrayscaledSourceBitmap;
      pictureBoxGreyscaled.Image = Grayscaled;
      pictureBoxGreyscaled.SizeMode = PictureBoxSizeMode.Zoom;

      levelX = 60;
      levelY = 160;

      numericUpDownLevelX.Value = levelX;
      numericUpDownLevelY.Value = levelY;

      checkBoxResultZoom.Checked = true;
      pictureBoxSolve.SizeMode = PictureBoxSizeMode.Zoom;

      DrawAndAnalyze();
    }

    void DrawAndAnalyze()
    {

      histX = new Dictionary<int, long>();
      histY = new Dictionary<int, long>();
      histXboolean = new Dictionary<int, bool>();
      histYboolean = new Dictionary<int, bool>();
      cellsX = new List<SourceCell>();
      cellsY = new List<SourceCell>();

      // gen histograms for Y
      for (int y = 0; y < GrayscaledSourceBitmap.Height; y++)
      {
        long hist = 0;
        for (int x = 0; x < GrayscaledSourceBitmap.Width; x++)
        {
          Color pixelColor = GrayscaledSourceBitmap.GetPixel(x, y);
          hist += pixelColor.R;
        }
        hist = hist / GrayscaledSourceBitmap.Width;
        histY[y] = hist;
      }

      // histogram Y analyze
      maxValY = histY.Select(i => i.Value).Max();

      pictureBoxHistY.Height = GrayscaledSourceBitmap.Height;
      pictureBoxHistY.Width = panelHistY.Width - 20;

      HistBitmapY = new Bitmap(pictureBoxHistY.Width, GrayscaledSourceBitmap.Height);
      refreshHistY(levelY, histY, histYboolean, HistBitmapY);

      pictureBoxHistY.Image = HistBitmapY;
      pictureBoxHistY.SizeMode = PictureBoxSizeMode.Zoom;

      fillCellTable(histYboolean, cellsY);
      var analyzY = analyzeCells(cellsY);
      var validWidthsY = getValidWidths(analyzY);
      var validCellsY = cellsY.Where(i => validWidthsY.Any(j => j == i.width)).OrderBy(i => i.number).ToArray();
      var errorY = checkCells(validCellsY, "Y", labelErrorsY);

      // gen histograms for X
      for (int x = 0; x < GrayscaledSourceBitmap.Width; x++)
      {
        long hist = 0;
        //for (int y = 0; y < GrayscaledSourceBitmap.Height; y++)
        for (int y = validCellsY.First().posAfterFront - validCellsY.First().front; y < validCellsY.Last().posAfterFront + validCellsY.Last().width + validCellsY.Last().back; y++)
        {
          Color pixelColor = GrayscaledSourceBitmap.GetPixel(x, y);
          hist += pixelColor.R;
        }
        hist = hist / GrayscaledSourceBitmap.Height;
        histX[x] = hist;
      }

      // histogram X analyze
      maxValX = histX.Select(i => i.Value).Max();

      pictureBoxHistX.Height = panelHistX.Height - 40;
      pictureBoxHistX.Width = GrayscaledSourceBitmap.Width;

      HistBitmapX = new Bitmap(GrayscaledSourceBitmap.Width, pictureBoxHistX.Height);
      refreshHistX(levelX, histX, histXboolean, HistBitmapX);

      pictureBoxHistX.Image = HistBitmapX;
      pictureBoxHistX.SizeMode = PictureBoxSizeMode.Zoom;

      fillCellTable(histXboolean, cellsX);
      var analyzX = analyzeCells(cellsX);
      var validWidthsX = getValidWidths(analyzX);
      var validCellsX = cellsX.Where(i => validWidthsX.Any(j => j == i.width)).OrderBy(i => i.number).ToArray();
      var errorX = checkCells(validCellsX, "X", labelErrorsX);

      if (!errorY && !errorX)
      {
        var res = OCR(validCellsX, validCellsY);

        _Solve.SolvePreparation(res);

        ShowSolvePlayArea();
      }

    }

    List<List<int>> OCR(SourceCell[] validCellsX, SourceCell[] validCellsY)
    {
      var res = new List<List<int>>();
      for (int iy = 0; iy < validCellsY.Length; iy++)
      {
        var resX = new List<int>();
        for (int ix = 0; ix < validCellsX.Length; ix++)
        {
          var widthX = validCellsX[ix].width;
          var widthY = validCellsY[iy].width;
          var bSprite = new Bitmap(widthX, widthY);

          long fullnessI = 0;

          for (int y = 0; y < widthY; y++)
            for (int x = 0; x < widthX; x++)
            {
              var pixColor = GrayscaledSourceBitmap.GetPixel(validCellsX[ix].posAfterFront + x, validCellsY[iy].posAfterFront + y);

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
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789");
            ocr.Init(@"", "eng", false);
            List<tessnet2.Word> result = ocr.DoOCR(bSprite, Rectangle.Empty);
            value = Convert.ToInt32(string.Join("", result.Select(i => i.Text)));
            //bSprite.Save($".\\digitals\\{string.Join("", result.Select(i => i.Text.Replace("|", "I")))} {string.Join("_", result.Select(i => i.Confidence))} {ix:00}-{iy:00}.png", ImageFormat.Png);
          }
          resX.Add(value);
        }
        res.Add(resX);
      }

      return res;
    }

    void refreshHistX(long level, Dictionary<int, long> histDictionary, Dictionary<int, bool> histBoolean, Bitmap resultBooleanHistogram)
    {
      foreach (var hist in histDictionary)
      {
        if (hist.Value < level)
        {
          histBoolean[hist.Key] = false;
        }
        else
        {
          histBoolean[hist.Key] = true;
        }

        for (int i = 0; i < resultBooleanHistogram.Height; i++)
        {
          if (i < 10)
          {
            if (hist.Value < level)
            {
              resultBooleanHistogram.SetPixel(hist.Key, i, Color.White);
            }
            else
            {
              resultBooleanHistogram.SetPixel(hist.Key, i, Color.Blue);
            }
          }
          else
          {
            if ((i - 10) < hist.Value * (resultBooleanHistogram.Height - 10) / maxValX)
              resultBooleanHistogram.SetPixel(hist.Key, i, Color.Gray);
            else
              resultBooleanHistogram.SetPixel(hist.Key, i, Color.White);

          }
        }
      }
    }

    void refreshHistY(long level, Dictionary<int, long> histDictionary, Dictionary<int, bool> histBoolean, Bitmap resultBooleanHistogram)
    {
      foreach (var hist in histDictionary)
      {
        for (int i = 0; i < resultBooleanHistogram.Width; i++)
        {
          if (i < 10)
          {
            if (hist.Value < level)
            {
              resultBooleanHistogram.SetPixel(i, hist.Key, Color.White);
              histBoolean[hist.Key] = false;
            }
            else
            {
              resultBooleanHistogram.SetPixel(i, hist.Key, Color.Blue);
              histBoolean[hist.Key] = true;
            }
          }
          else
          {
            if ((i - 10) < hist.Value * (resultBooleanHistogram.Width - 10) / maxValY)
              resultBooleanHistogram.SetPixel(i, hist.Key, Color.Gray);
            else resultBooleanHistogram.SetPixel(i, hist.Key, Color.White);

          }
        }
      }
    }

    void fillCellTable(Dictionary<int, bool> histboolean, List<SourceCell> cells)
    {
      var lastV = false;
      var front = 0;
      var number = 0;
      var currentCell = default(SourceCell);

      foreach (var hist in histboolean)
      {
        if (hist.Value != lastV)
        {
          if (hist.Value)
          {
            if (currentCell != null)
            {
              currentCell.back = hist.Key - currentCell.posAfterFront - currentCell.width;
              front = currentCell.back;
              currentCell.number = number++;
              cells.Add(currentCell);
            }
            currentCell = new SourceCell { front = front, posAfterFront = hist.Key };
          }
          else
          {
            currentCell.width = hist.Key - currentCell.posAfterFront;
          }
          lastV = hist.Value;
        }

      }
    }

    Dictionary<int, int> analyzeCells(List<SourceCell> cells)
    {
      var res = new Dictionary<int, int>();
      int val;
      foreach (var cell in cells)
      {
        if (res.TryGetValue(cell.width, out val))
        {
          res[cell.width] = val + 1;
        }
        else res[cell.width] = 1;
      }
      return res;
    }

    int[] getValidWidths(Dictionary<int, int> analyzed)
    {
      var maxFreq = analyzed.Max(i => i.Value);
      var maxWidth = analyzed.FirstOrDefault(i => i.Value == maxFreq).Key;
      var limMin90 = maxWidth * 0.9;
      var limMax90 = maxWidth / 0.9;
      return analyzed.Where(i => limMin90 < i.Key && i.Key < limMax90).Select(i => i.Key).ToArray();
    }

    private void numericUpDownLevelX_ValueChanged(object sender, EventArgs e)
    {
      levelX = (int)numericUpDownLevelX.Value;
    }

    private void numericUpDownLevelY_ValueChanged(object sender, EventArgs e)
    {
      levelY = (int)numericUpDownLevelY.Value;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DrawAndAnalyze();
    }

    bool checkCells(SourceCell[] validCells, string axisName, Label label)
    {
      var prevNumb = -1;
      foreach (var cell in validCells)
      {
        if (cell.number - prevNumb > 1 && prevNumb != -1)
        {
          label.Text = $"{axisName} errors: The cells do not go one after another.";
          return true;
        }
        else prevNumb = cell.number;
      }
      label.Text = $"axis {axisName} - ok, valid cells:{validCells.Length}";
      return false; // no errors
    }

    private void button2_Click(object sender, EventArgs e)
    {
      _Solve.SolveHorizStep();
      ShowSolvePlayArea();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      _Solve.SolveVertStep();
      ShowSolvePlayArea();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      _Solve.DescriptorsInit();
      ShowSolvePlayArea();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      _Solve.SolveSmallStepH((int)numericUpDownHStep.Value);
      ShowSolvePlayArea();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      _Solve.SolveSmallStepV((int)numericUpDownVStep.Value);
      ShowSolvePlayArea();
    }

    private void checkBoxResultZoom_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxResultZoom.Checked)
      {
        pictureBoxSolve.Dock = DockStyle.Fill;
        pictureBoxSolve.SizeMode = PictureBoxSizeMode.Zoom;
      }
      else
      {
        var bitmap = pictureBoxSolve.Image;
        pictureBoxSolve.Width = bitmap.Width;
        pictureBoxSolve.Height = bitmap.Height;

        pictureBoxSolve.Dock = DockStyle.None;
        pictureBoxSolve.SizeMode = PictureBoxSizeMode.Normal;
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      _Solve.SolveTestInit();
      ShowSolvePlayArea();
    }

    private void button8_Click(object sender, EventArgs e)
    {
      _Solve.SolveTestGo();
      ShowSolvePlayArea();
    }

    private void button9_Click(object sender, EventArgs e)
    {
      if (!backgroundWorker1.IsBusy)
        backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      do
      {
        SolveLog.Instance.ResetChangesCounter();

        _Solve.SolveVertStep();
        //System.Threading.Thread.Sleep(100);
        pictureBoxSolve.Invoke(new Action(() => ShowSolvePlayArea()));

        _Solve.SolveHorizStep();
        //System.Threading.Thread.Sleep(100);
        pictureBoxSolve.Invoke(new Action(() => ShowSolvePlayArea()));

      } while (SolveLog.Instance.Changes > 0);
    }

    void ShowSolvePlayArea()
    {

      List<DescriptorData>[] rowDescrV = _Solve.rowDescrV;
      List<DescriptorData>[] rowDescrH = _Solve.rowDescrH;
      var playArea = _Solve.PlayArea;

      var sizePA_X = playArea.SizeX;
      var sizePA_Y = playArea.SizeY;

      var sizeDescr_X = rowDescrH.Max(i => i.Count);
      var sizeDescr_Y = rowDescrV.Max(i => i.Count);

      var widthCell = 16;
      var margin = 1;
      var netWidth = 1;
      var widthQuadrat = widthCell - (margin * 2) - netWidth;

      var bitmap = new Bitmap(widthCell * (sizePA_X + sizeDescr_X) + netWidth, widthCell * (sizePA_Y + sizeDescr_Y) + netWidth);
      pictureBoxSolve.Image = bitmap;

      if (!checkBoxResultZoom.Checked)
      {
        pictureBoxSolve.Width = bitmap.Width;
        pictureBoxSolve.Height = bitmap.Height;
      }

      Graphics g = Graphics.FromImage(bitmap);
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
      g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;


      //playArea[0, 0].tCell = TCell.X;

      for (int gy = 0; gy < sizePA_Y + sizeDescr_Y; gy++)
      {
        for (int gx = 0; gx < sizePA_X + sizeDescr_X; gx++)
        {
          for (int iy = 0; iy < widthCell; iy++)
          {
            for (int ix = 0; ix < widthCell; ix++)
            {
              if (gx < sizeDescr_X && gy < sizeDescr_Y) continue;

              var xx = gx * widthCell + ix;
              var yy = gy * widthCell + iy;

              if (iy < netWidth || ix < netWidth) bitmap.SetPixel(xx, yy, Color.Gray);
              else
              {
                if ((gx < sizeDescr_X || gy < sizeDescr_Y))
                {
                  // draw descr
                  if (gx < sizeDescr_X)
                  {
                    // draw rowDescrY
                    var indx = gy - sizeDescr_Y;
                    var indx2 = gx - (sizeDescr_X - rowDescrH[indx].Count);
                    if (indx2 >= 0)
                    {
                      var numb = rowDescrH[indx][indx2].Value;

                      if (ix == 3 && iy == 2)
                      {
                        RectangleF rectf = new RectangleF(gx * widthCell + ix, gy * widthCell + iy, widthCell, widthCell);
                        g.DrawString(numb.ToString(), new Font("Arial", 8), Brushes.Black, rectf);
                        g.Flush();
                      }

                      if ((ix == iy || widthCell - ix == iy)
                        && ix >= netWidth + margin * 2 && iy >= netWidth + margin * 2
                        && ix < widthCell - margin * 2 && iy < widthCell - margin * 2
                        && rowDescrH[indx][indx2].isSolved())
                        bitmap.SetPixel(xx, yy, Color.Black);
                    }

                  }
                  else
                  {
                    // draw rowDescrX
                    var indx = gx - sizeDescr_X;
                    var indx2 = gy - (sizeDescr_Y - rowDescrV[indx].Count);
                    if (indx2 >= 0)
                    {
                      var numb = rowDescrV[indx][indx2].Value;

                      if (ix == 3 && iy == 2)
                      {
                        RectangleF rectf = new RectangleF(gx * widthCell + ix, gy * widthCell + iy, widthCell, widthCell);
                        g.DrawString(numb.ToString(), new Font("Arial", 8), Brushes.Black, rectf);
                        g.Flush();
                      }

                      if ((ix == iy || widthCell - ix == iy)
                        && ix >= netWidth + margin * 2 && iy >= netWidth + margin * 2
                        && ix < widthCell - margin * 2 && iy < widthCell - margin * 2
                        && rowDescrV[indx][indx2].isSolved())
                        bitmap.SetPixel(xx, yy, Color.Black);
                    }

                  }
                }
                else
                {
                  // draw playArea

                  var x = gx - sizeDescr_X;
                  var y = gy - sizeDescr_Y;

                  if (playArea.GetValue(x, y) == TCell.No) bitmap.SetPixel(xx, yy, Color.White);

                  if (playArea.GetValue(x, y) == TCell.F)
                  {
                    if (iy < netWidth + margin || ix < netWidth + margin) bitmap.SetPixel(xx, yy, Color.White);
                    else
                    {
                      if (ix < widthCell - margin && iy < widthCell - margin) bitmap.SetPixel(xx, yy, Color.Black);
                      else bitmap.SetPixel(xx, yy, Color.White);
                    }
                  }

                  if (playArea.GetValue(x, y) == TCell.X)
                  {
                    if ((ix == iy || widthCell - ix == iy)
                      && ix >= netWidth + margin * 2 && iy >= netWidth + margin * 2
                      && ix < widthCell - margin * 2 && iy < widthCell - margin * 2) bitmap.SetPixel(xx, yy, Color.Black);
                    else bitmap.SetPixel(xx, yy, Color.White);
                  }
                }
              }
            }
          }
        }
      }

      // last horizontal line
      for (int x = 0; x < bitmap.Width; x++)
        for (int i = 0; i < netWidth; i++)
          bitmap.SetPixel(x, bitmap.Height - 1 - i, Color.Gray);

      // last vertical line
      for (int y = 0; y < bitmap.Height; y++)
        for (int i = 0; i < netWidth; i++)
          bitmap.SetPixel(bitmap.Width - 1 - i, y, Color.Gray);

    }

  }
}

