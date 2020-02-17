using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mainView
{
  public partial class LineAnalyzeForm : Form
  {
    Bitmap sourceBitmap;
    bool isVertical;

    int GetPixel(int x, int y) => isVertical ? sourceBitmap.GetPixel(y, x).R : sourceBitmap.GetPixel(x, y).R;

    int GetWidth() => isVertical ? sourceBitmap.Height : sourceBitmap.Width;
    int GetHeight() => isVertical ? sourceBitmap.Width : sourceBitmap.Height;

    public LineAnalyzeForm(Bitmap sourceBitmap, int lineNumber, bool isVertical)
    {
      InitializeComponent();

      this.sourceBitmap = sourceBitmap;
      this.isVertical = isVertical;

      numericUpDownLineNumber.Minimum = 0;
      numericUpDownLineNumber.Maximum = GetHeight() - 1;
      numericUpDownLineNumber.Value = lineNumber;

      ShowAnalyzeLine();
    }

    void ShowAnalyzeLine()
    {
      if (sourceBitmap == null) return;
      var bitmap = new Bitmap(GetWidth(), pictureBoxAnalyze.Height);
      pictureBoxAnalyze.Image = bitmap;

      var Averager = new AverageWithWindow((int)numericUpDownAverrageWindow.Value);

      for (int x = 0; x < GetWidth(); x++)
      {
        var color = GetPixel(x, (int)numericUpDownLineNumber.Value);
        var averragedColor = Averager.NewValue(color);
        if (checkBoxAverage.Checked) color = (byte)averragedColor;
        for (int y = 0; y < bitmap.Height; y++)
        {
          if (y * 255 / bitmap.Height < color) bitmap.SetPixel(x, bitmap.Height - y - 1, Color.White);
          else bitmap.SetPixel(x, bitmap.Height - y - 1, Color.Black);
        }
      }

    }

    private void numericUpDownLineNumber_ValueChanged(object sender, EventArgs e)
    {
      ShowAnalyzeLine();
    }

    private void pictureBoxAnalyze_Click(object sender, EventArgs e)
    {
      var x = (e as MouseEventArgs).X;
      labelX.Text = x.ToString();
      labelColor.Text = GetPixel(x, (int)numericUpDownLineNumber.Value).ToString();
    }

    private void numericUpDownAverrageWindow_ValueChanged(object sender, EventArgs e)
    {
      ShowAnalyzeLine();
    }

    private void checkBoxAverage_CheckedChanged(object sender, EventArgs e)
    {
      ShowAnalyzeLine();
    }

    private void LineAnalyzeForm_Resize(object sender, EventArgs e)
    {
      ShowAnalyzeLine();
    }
  }


}
