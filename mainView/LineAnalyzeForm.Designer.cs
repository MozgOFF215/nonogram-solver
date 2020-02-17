namespace mainView
{
  partial class LineAnalyzeForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.numericUpDownLineNumber = new System.Windows.Forms.NumericUpDown();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pictureBoxAnalyze = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.labelX = new System.Windows.Forms.Label();
      this.labelColor = new System.Windows.Forms.Label();
      this.checkBoxAverage = new System.Windows.Forms.CheckBox();
      this.numericUpDownAverrageWindow = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineNumber)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnalyze)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverrageWindow)).BeginInit();
      this.SuspendLayout();
      // 
      // numericUpDownLineNumber
      // 
      this.numericUpDownLineNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.numericUpDownLineNumber.Location = new System.Drawing.Point(169, 5);
      this.numericUpDownLineNumber.Name = "numericUpDownLineNumber";
      this.numericUpDownLineNumber.Size = new System.Drawing.Size(84, 22);
      this.numericUpDownLineNumber.TabIndex = 0;
      this.numericUpDownLineNumber.ValueChanged += new System.EventHandler(this.numericUpDownLineNumber_ValueChanged);
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
      this.panel1.Controls.Add(this.pictureBoxAnalyze);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 35);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1093, 386);
      this.panel1.TabIndex = 1;
      // 
      // pictureBoxAnalyze
      // 
      this.pictureBoxAnalyze.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxAnalyze.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxAnalyze.Name = "pictureBoxAnalyze";
      this.pictureBoxAnalyze.Size = new System.Drawing.Size(1093, 386);
      this.pictureBoxAnalyze.TabIndex = 0;
      this.pictureBoxAnalyze.TabStop = false;
      this.pictureBoxAnalyze.Click += new System.EventHandler(this.pictureBoxAnalyze_Click);
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(76, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Line number";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.numericUpDownLineNumber, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.labelX, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.labelColor, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.checkBoxAverage, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.numericUpDownAverrageWindow, 3, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1099, 475);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(142, 428);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(21, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "X:";
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(118, 453);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 17);
      this.label3.TabIndex = 2;
      this.label3.Text = "Color:";
      // 
      // labelX
      // 
      this.labelX.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelX.AutoSize = true;
      this.labelX.Location = new System.Drawing.Point(169, 428);
      this.labelX.Name = "labelX";
      this.labelX.Size = new System.Drawing.Size(21, 17);
      this.labelX.TabIndex = 2;
      this.labelX.Text = "X:";
      // 
      // labelColor
      // 
      this.labelColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelColor.AutoSize = true;
      this.labelColor.Location = new System.Drawing.Point(169, 453);
      this.labelColor.Name = "labelColor";
      this.labelColor.Size = new System.Drawing.Size(45, 17);
      this.labelColor.TabIndex = 2;
      this.labelColor.Text = "Color:";
      // 
      // checkBoxAverage
      // 
      this.checkBoxAverage.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.checkBoxAverage.AutoSize = true;
      this.checkBoxAverage.Location = new System.Drawing.Point(366, 5);
      this.checkBoxAverage.Name = "checkBoxAverage";
      this.checkBoxAverage.Size = new System.Drawing.Size(118, 21);
      this.checkBoxAverage.TabIndex = 3;
      this.checkBoxAverage.Text = "use averrage:";
      this.checkBoxAverage.UseVisualStyleBackColor = true;
      this.checkBoxAverage.CheckedChanged += new System.EventHandler(this.checkBoxAverage_CheckedChanged);
      // 
      // numericUpDownAverrageWindow
      // 
      this.numericUpDownAverrageWindow.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.numericUpDownAverrageWindow.Location = new System.Drawing.Point(490, 5);
      this.numericUpDownAverrageWindow.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.numericUpDownAverrageWindow.Name = "numericUpDownAverrageWindow";
      this.numericUpDownAverrageWindow.Size = new System.Drawing.Size(61, 22);
      this.numericUpDownAverrageWindow.TabIndex = 4;
      this.numericUpDownAverrageWindow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericUpDownAverrageWindow.ValueChanged += new System.EventHandler(this.numericUpDownAverrageWindow_ValueChanged);
      // 
      // LineAnalyzeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1099, 475);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "LineAnalyzeForm";
      this.Text = "LineAnalyzeForm";
      this.Resize += new System.EventHandler(this.LineAnalyzeForm_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineNumber)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnalyze)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverrageWindow)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown numericUpDownLineNumber;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBoxAnalyze;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelX;
    private System.Windows.Forms.Label labelColor;
    private System.Windows.Forms.CheckBox checkBoxAverage;
    private System.Windows.Forms.NumericUpDown numericUpDownAverrageWindow;
  }
}