using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

    Solver _Solver = new Solver();

    Dictionary<int, int> histX;
    Dictionary<int, int> histY;

    Bitmap SourceBitmap;
    Bitmap GrayscaledSourceBitmap;
    Bitmap HistBitmapX;
    Bitmap HistBitmapY;
    int maxValX;
    int maxValY;
    int levelX, levelY;

    Image sourceImage;

    void MainForm_Load(object sender, EventArgs e)
    {
      Logic.InitOCRResultSaver();

      //sourceImage = Image.FromFile("images\\Screenshot_20x20.png");
      //sourceImage = Image.FromFile("images\\Screenshot_25x25.png");
      sourceImage = Image.FromFile("images\\Screenshot_25x25_2.png");
      //sourceImage = Image.FromFile("images\\Screenshot_25x25_3.png");

      levelX = 60;
      levelY = 160;

      numericUpDownLevelX.Value = levelX;
      numericUpDownLevelY.Value = levelY;

      DrawAndAnalyze(sourceImage);
    }

    void DrawAndAnalyze(Image sourceImage = null)
    {
      sourceImage = sourceImage == null ? this.sourceImage : sourceImage;
      this.sourceImage = sourceImage;

      SourceBitmap = new Bitmap(sourceImage);

      GrayscaledSourceBitmap = BitmapUtils.MakeGrayscale3(new Bitmap(sourceImage));

      checkBoxOriginalZoom.Checked = true;
      pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBoxOriginal.Image = sourceImage;

      checkBoxSolveZoom.Checked = true;
      pictureBoxSolve.SizeMode = PictureBoxSizeMode.Zoom;

      histX = new Dictionary<int, int>();
      histY = new Dictionary<int, int>();

      // search horizontal lines 
      var level = 150;
      var markedLinesY = Logic.SearchLines(
        GrayscaledSourceBitmap.Height,
        GrayscaledSourceBitmap.Width,
        level,
        (x, y) => GrayscaledSourceBitmap.GetPixel(x, y).R
      );

      // prepare crop from up and down
      var startY = markedLinesY.First().start;
      var endY = markedLinesY.Last().start + markedLinesY.Last().length;
      var heightY = endY - startY + 1;

      // crop bitmap
      GrayscaledSourceBitmap = Logic.Crop(GrayscaledSourceBitmap, startY - 5, heightY + 10);
      pictureBoxOriginal.Image = GrayscaledSourceBitmap;

      // second iteration while bitmap croped
      markedLinesY = Logic.SearchLines(
        GrayscaledSourceBitmap.Height,
        GrayscaledSourceBitmap.Width,
        level,
        (x, y) => GrayscaledSourceBitmap.GetPixel(x, y).R
      );

      // search vertical lines
      var markedLinesX = Logic.SearchLines(
        GrayscaledSourceBitmap.Width,
        GrayscaledSourceBitmap.Height,
        150,
        (y, x) => GrayscaledSourceBitmap.GetPixel(x, y).R
      );

      // gen histograms for Y
      histY = Logic.GenHistogram(GrayscaledSourceBitmap.Height, GrayscaledSourceBitmap.Width,
        (x, y) => GrayscaledSourceBitmap.GetPixel(x, y).R);

      // histogram Y analyze
      maxValY = histY.Select(i => i.Value).Max();

      pictureBoxHistY.Height = GrayscaledSourceBitmap.Height;
      pictureBoxHistY.Width = panelHistY.Width - 20;

      HistBitmapY = new Bitmap(pictureBoxHistY.Width, GrayscaledSourceBitmap.Height);
      Logic.RefreshHistY(levelY, histY, HistBitmapY, markedLinesY, maxValY);

      pictureBoxHistY.Image = HistBitmapY;
      pictureBoxHistY.SizeMode = PictureBoxSizeMode.Zoom;

      // gen histograms for X
      histX = Logic.GenHistogram(GrayscaledSourceBitmap.Width, GrayscaledSourceBitmap.Height,
        (y, x) => GrayscaledSourceBitmap.GetPixel(x, y).R);

      // histogram X analyze
      maxValX = histX.Select(i => i.Value).Max();

      pictureBoxHistX.Height = panelHistX.Height - 40;
      pictureBoxHistX.Width = GrayscaledSourceBitmap.Width;

      HistBitmapX = new Bitmap(GrayscaledSourceBitmap.Width, pictureBoxHistX.Height);
      Logic.RefreshHistX(levelX, histX, HistBitmapX, markedLinesX, maxValX);

      pictureBoxHistX.Image = HistBitmapX;
      pictureBoxHistX.SizeMode = PictureBoxSizeMode.Zoom;

      try
      {
        var resOCR = Logic.OCR(markedLinesX, markedLinesY, GrayscaledSourceBitmap.GetPixel);
        _Solver.SolvePreparation(resOCR);
        ShowSolvePlayArea();
      }
      catch
      {

      }
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

    private void button2_Click(object sender, EventArgs e)
    {
      _Solver.SolveHorizStep();
      ShowSolvePlayArea();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      _Solver.SolveVertStep();
      ShowSolvePlayArea();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      _Solver.DescriptorsInit();
      ShowSolvePlayArea();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      _Solver.SolveSmallStepH((int)numericUpDownHStep.Value);
      ShowSolvePlayArea();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      _Solver.SolveSmallStepV((int)numericUpDownVStep.Value);
      ShowSolvePlayArea();
    }

    private void checkBoxSolveZoom_CheckedChanged(object sender, EventArgs e)
    {
      ZoomProcessing(pictureBoxSolve, checkBoxSolveZoom);
    }

    private void ZoomProcessing(PictureBox pictureBox, CheckBox checkBox)
    {
      if (checkBox.Checked)
      {
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
      }
      else
      {
        var bitmap = pictureBox.Image;
        if (bitmap == null) return;
        pictureBox.Width = bitmap.Width;
        pictureBox.Height = bitmap.Height;

        pictureBox.Dock = DockStyle.None;
        pictureBox.SizeMode = PictureBoxSizeMode.Normal;
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      _Solver.SolveTestInit();
      ShowSolvePlayArea();
    }

    private void button8_Click(object sender, EventArgs e)
    {
      _Solver.SolveTestGo();
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

        _Solver.SolveVertStep();
        //System.Threading.Thread.Sleep(100);
        pictureBoxSolve.Invoke(new Action(() => ShowSolvePlayArea()));

        _Solver.SolveHorizStep();
        //System.Threading.Thread.Sleep(100);
        pictureBoxSolve.Invoke(new Action(() => ShowSolvePlayArea()));

      } while (SolveLog.Instance.Changes > 0);
    }

    private void button10_Click(object sender, EventArgs e)
    {
      var dlg = new OpenFileDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        var stream = dlg.OpenFile();
        var image = Image.FromStream(stream);
        DrawAndAnalyze(image);
      }
    }

    private void checkBoxOriginalZoom_CheckedChanged(object sender, EventArgs e)
    {
      ZoomProcessing(pictureBoxOriginal, checkBoxOriginalZoom);
    }

    private void pictureBoxHistY_Click(object sender, EventArgs e)
    {
      var lineAnalizeForm = new LineAnalyzeForm(GrayscaledSourceBitmap, (e as MouseEventArgs).Y, false);
      lineAnalizeForm.Show();
    }

    private void pictureBoxHistX_Click(object sender, EventArgs e)
    {
      var lineAnalizeForm = new LineAnalyzeForm(GrayscaledSourceBitmap, (e as MouseEventArgs).X, true);
      lineAnalizeForm.Show();
    }

    void ShowSolvePlayArea()
    {

      List<DescriptorData>[] rowDescrV = _Solver.rowDescrV;
      List<DescriptorData>[] rowDescrH = _Solver.rowDescrH;
      var playArea = _Solver.PlayArea;

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

      if (!checkBoxSolveZoom.Checked)
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

