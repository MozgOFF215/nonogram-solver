namespace mainView
{
  partial class MainForm
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
      this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
      this.pictureBoxHistY = new System.Windows.Forms.PictureBox();
      this.panelHistY = new System.Windows.Forms.Panel();
      this.labelErrorsX = new System.Windows.Forms.Label();
      this.numericUpDownLevelX = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownLevelY = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.labelErrorsY = new System.Windows.Forms.Label();
      this.panelHistX = new System.Windows.Forms.Panel();
      this.pictureBoxHistX = new System.Windows.Forms.PictureBox();
      this.pictureBoxSolve = new System.Windows.Forms.PictureBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.numericUpDownHStep = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownVStep = new System.Windows.Forms.NumericUpDown();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.checkBoxSolveZoom = new System.Windows.Forms.CheckBox();
      this.panelSolve = new System.Windows.Forms.Panel();
      this.button7 = new System.Windows.Forms.Button();
      this.button8 = new System.Windows.Forms.Button();
      this.button9 = new System.Windows.Forms.Button();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button10 = new System.Windows.Forms.Button();
      this.checkBoxOriginalZoom = new System.Windows.Forms.CheckBox();
      this.panelOriginal = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistY)).BeginInit();
      this.panelHistY.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelY)).BeginInit();
      this.panelHistX.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolve)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHStep)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVStep)).BeginInit();
      this.panelSolve.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.panelOriginal.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBoxOriginal
      // 
      this.pictureBoxOriginal.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxOriginal.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBoxOriginal.Name = "pictureBoxOriginal";
      this.pictureBoxOriginal.Size = new System.Drawing.Size(308, 543);
      this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxOriginal.TabIndex = 0;
      this.pictureBoxOriginal.TabStop = false;
      // 
      // pictureBoxHistY
      // 
      this.pictureBoxHistY.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxHistY.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBoxHistY.Name = "pictureBoxHistY";
      this.pictureBoxHistY.Size = new System.Drawing.Size(323, 415);
      this.pictureBoxHistY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxHistY.TabIndex = 0;
      this.pictureBoxHistY.TabStop = false;
      this.pictureBoxHistY.Click += new System.EventHandler(this.pictureBoxHistY_Click);
      // 
      // panelHistY
      // 
      this.panelHistY.AutoScroll = true;
      this.panelHistY.Controls.Add(this.pictureBoxHistY);
      this.panelHistY.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelHistY.Location = new System.Drawing.Point(402, 34);
      this.panelHistY.Margin = new System.Windows.Forms.Padding(4);
      this.panelHistY.Name = "panelHistY";
      this.panelHistY.Size = new System.Drawing.Size(205, 559);
      this.panelHistY.TabIndex = 1;
      // 
      // labelErrorsX
      // 
      this.labelErrorsX.AutoSize = true;
      this.labelErrorsX.Location = new System.Drawing.Point(42, 616);
      this.labelErrorsX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelErrorsX.Name = "labelErrorsX";
      this.labelErrorsX.Size = new System.Drawing.Size(83, 17);
      this.labelErrorsX.TabIndex = 4;
      this.labelErrorsX.Text = "---------------";
      // 
      // numericUpDownLevelX
      // 
      this.numericUpDownLevelX.Location = new System.Drawing.Point(182, 15);
      this.numericUpDownLevelX.Margin = new System.Windows.Forms.Padding(4);
      this.numericUpDownLevelX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownLevelX.Name = "numericUpDownLevelX";
      this.numericUpDownLevelX.Size = new System.Drawing.Size(91, 22);
      this.numericUpDownLevelX.TabIndex = 5;
      this.numericUpDownLevelX.ValueChanged += new System.EventHandler(this.numericUpDownLevelX_ValueChanged);
      // 
      // numericUpDownLevelY
      // 
      this.numericUpDownLevelY.Location = new System.Drawing.Point(182, 47);
      this.numericUpDownLevelY.Margin = new System.Windows.Forms.Padding(4);
      this.numericUpDownLevelY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownLevelY.Name = "numericUpDownLevelY";
      this.numericUpDownLevelY.Size = new System.Drawing.Size(91, 22);
      this.numericUpDownLevelY.TabIndex = 6;
      this.numericUpDownLevelY.ValueChanged += new System.EventHandler(this.numericUpDownLevelY_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(27, 20);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 17);
      this.label1.TabIndex = 7;
      this.label1.Text = "Level X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(27, 55);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 17);
      this.label2.TabIndex = 7;
      this.label2.Text = "Level Y";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(30, 162);
      this.button1.Margin = new System.Windows.Forms.Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(119, 36);
      this.button1.TabIndex = 8;
      this.button1.Text = "Rescan";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // labelErrorsY
      // 
      this.labelErrorsY.AutoSize = true;
      this.labelErrorsY.Location = new System.Drawing.Point(42, 632);
      this.labelErrorsY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelErrorsY.Name = "labelErrorsY";
      this.labelErrorsY.Size = new System.Drawing.Size(83, 17);
      this.labelErrorsY.TabIndex = 4;
      this.labelErrorsY.Text = "---------------";
      // 
      // panelHistX
      // 
      this.panelHistX.AutoScroll = true;
      this.tableLayoutPanel1.SetColumnSpan(this.panelHistX, 3);
      this.panelHistX.Controls.Add(this.pictureBoxHistX);
      this.panelHistX.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelHistX.Location = new System.Drawing.Point(4, 601);
      this.panelHistX.Margin = new System.Windows.Forms.Padding(4);
      this.panelHistX.Name = "panelHistX";
      this.panelHistX.Size = new System.Drawing.Size(1001, 177);
      this.panelHistX.TabIndex = 2;
      // 
      // pictureBoxHistX
      // 
      this.pictureBoxHistX.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxHistX.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBoxHistX.Name = "pictureBoxHistX";
      this.pictureBoxHistX.Size = new System.Drawing.Size(323, 319);
      this.pictureBoxHistX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxHistX.TabIndex = 0;
      this.pictureBoxHistX.TabStop = false;
      this.pictureBoxHistX.Click += new System.EventHandler(this.pictureBoxHistX_Click);
      // 
      // pictureBoxSolve
      // 
      this.pictureBoxSolve.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxSolve.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxSolve.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBoxSolve.Name = "pictureBoxSolve";
      this.pictureBoxSolve.Size = new System.Drawing.Size(392, 563);
      this.pictureBoxSolve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxSolve.TabIndex = 0;
      this.pictureBoxSolve.TabStop = false;
      this.pictureBoxSolve.Click += new System.EventHandler(this.pictureBoxSolve_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(19, 23);
      this.button2.Margin = new System.Windows.Forms.Padding(4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(240, 38);
      this.button2.TabIndex = 8;
      this.button2.Text = "Horizontal step";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(19, 69);
      this.button3.Margin = new System.Windows.Forms.Padding(4);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(240, 38);
      this.button3.TabIndex = 8;
      this.button3.Text = "Vertical step";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(171, 162);
      this.button4.Margin = new System.Windows.Forms.Padding(4);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(119, 36);
      this.button4.TabIndex = 8;
      this.button4.Text = "Clear";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // numericUpDownHStep
      // 
      this.numericUpDownHStep.Location = new System.Drawing.Point(184, 118);
      this.numericUpDownHStep.Margin = new System.Windows.Forms.Padding(4);
      this.numericUpDownHStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownHStep.Name = "numericUpDownHStep";
      this.numericUpDownHStep.Size = new System.Drawing.Size(75, 22);
      this.numericUpDownHStep.TabIndex = 5;
      // 
      // numericUpDownVStep
      // 
      this.numericUpDownVStep.Location = new System.Drawing.Point(184, 153);
      this.numericUpDownVStep.Margin = new System.Windows.Forms.Padding(4);
      this.numericUpDownVStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownVStep.Name = "numericUpDownVStep";
      this.numericUpDownVStep.Size = new System.Drawing.Size(75, 22);
      this.numericUpDownVStep.TabIndex = 5;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(19, 114);
      this.button5.Margin = new System.Windows.Forms.Padding(4);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(157, 28);
      this.button5.TabIndex = 9;
      this.button5.Text = "Solve Line №";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(19, 150);
      this.button6.Margin = new System.Windows.Forms.Padding(4);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(157, 28);
      this.button6.TabIndex = 9;
      this.button6.Text = "Solve Column №";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // checkBoxSolveZoom
      // 
      this.checkBoxSolveZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.checkBoxSolveZoom.AutoSize = true;
      this.checkBoxSolveZoom.Location = new System.Drawing.Point(777, 4);
      this.checkBoxSolveZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.checkBoxSolveZoom.Name = "checkBoxSolveZoom";
      this.checkBoxSolveZoom.Size = new System.Drawing.Size(66, 21);
      this.checkBoxSolveZoom.TabIndex = 10;
      this.checkBoxSolveZoom.Text = "Zoom";
      this.checkBoxSolveZoom.UseVisualStyleBackColor = true;
      this.checkBoxSolveZoom.CheckedChanged += new System.EventHandler(this.checkBoxSolveZoom_CheckedChanged);
      // 
      // panelSolve
      // 
      this.panelSolve.AutoScroll = true;
      this.panelSolve.Controls.Add(this.pictureBoxSolve);
      this.panelSolve.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelSolve.Location = new System.Drawing.Point(614, 32);
      this.panelSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panelSolve.Name = "panelSolve";
      this.panelSolve.Size = new System.Drawing.Size(392, 563);
      this.panelSolve.TabIndex = 11;
      // 
      // button7
      // 
      this.button7.Location = new System.Drawing.Point(16, 23);
      this.button7.Margin = new System.Windows.Forms.Padding(4);
      this.button7.Name = "button7";
      this.button7.Size = new System.Drawing.Size(100, 28);
      this.button7.TabIndex = 12;
      this.button7.Text = "Init Test";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new System.EventHandler(this.button7_Click);
      // 
      // button8
      // 
      this.button8.Location = new System.Drawing.Point(156, 23);
      this.button8.Margin = new System.Windows.Forms.Padding(4);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(100, 28);
      this.button8.TabIndex = 12;
      this.button8.Text = "Start Test";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new System.EventHandler(this.button8_Click);
      // 
      // button9
      // 
      this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button9.Location = new System.Drawing.Point(30, 219);
      this.button9.Margin = new System.Windows.Forms.Padding(4);
      this.button9.Name = "button9";
      this.button9.Size = new System.Drawing.Size(260, 59);
      this.button9.TabIndex = 13;
      this.button9.Text = "Full Solve";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new System.EventHandler(this.button9_Click);
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.button3);
      this.groupBox1.Controls.Add(this.button5);
      this.groupBox1.Controls.Add(this.numericUpDownHStep);
      this.groupBox1.Controls.Add(this.numericUpDownVStep);
      this.groupBox1.Controls.Add(this.button6);
      this.groupBox1.Location = new System.Drawing.Point(27, 311);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(267, 196);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Solve by step";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.button7);
      this.groupBox2.Controls.Add(this.button8);
      this.groupBox2.Location = new System.Drawing.Point(30, 529);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox2.Size = new System.Drawing.Size(264, 71);
      this.groupBox2.TabIndex = 16;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Test";
      // 
      // button10
      // 
      this.button10.Location = new System.Drawing.Point(30, 111);
      this.button10.Margin = new System.Windows.Forms.Padding(4);
      this.button10.Name = "button10";
      this.button10.Size = new System.Drawing.Size(119, 36);
      this.button10.TabIndex = 17;
      this.button10.Text = "Load image";
      this.button10.UseVisualStyleBackColor = true;
      this.button10.Click += new System.EventHandler(this.button10_Click);
      // 
      // checkBoxOriginalZoom
      // 
      this.checkBoxOriginalZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.checkBoxOriginalZoom.AutoSize = true;
      this.checkBoxOriginalZoom.Location = new System.Drawing.Point(166, 4);
      this.checkBoxOriginalZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.checkBoxOriginalZoom.Name = "checkBoxOriginalZoom";
      this.checkBoxOriginalZoom.Size = new System.Drawing.Size(66, 21);
      this.checkBoxOriginalZoom.TabIndex = 18;
      this.checkBoxOriginalZoom.Text = "Zoom";
      this.checkBoxOriginalZoom.UseVisualStyleBackColor = true;
      this.checkBoxOriginalZoom.CheckedChanged += new System.EventHandler(this.checkBoxOriginalZoom_CheckedChanged);
      // 
      // panelOriginal
      // 
      this.panelOriginal.AutoScroll = true;
      this.panelOriginal.Controls.Add(this.pictureBoxOriginal);
      this.panelOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelOriginal.Location = new System.Drawing.Point(3, 32);
      this.panelOriginal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panelOriginal.Name = "panelOriginal";
      this.panelOriginal.Size = new System.Drawing.Size(392, 563);
      this.panelOriginal.TabIndex = 19;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
      this.tableLayoutPanel1.Controls.Add(this.checkBoxOriginalZoom, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panelOriginal, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.panelSolve, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.panelHistY, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.checkBoxSolveZoom, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.panelHistX, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1324, 782);
      this.tableLayoutPanel1.TabIndex = 20;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.button10);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.numericUpDownLevelX);
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.button4);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.labelErrorsX);
      this.panel1.Controls.Add(this.button9);
      this.panel1.Controls.Add(this.labelErrorsY);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.numericUpDownLevelY);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(1012, 3);
      this.panel1.Name = "panel1";
      this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
      this.panel1.Size = new System.Drawing.Size(309, 776);
      this.panel1.TabIndex = 20;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1324, 782);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainForm";
      this.Text = "Nonogram Solver. Copyright © MozgOFF, 2020";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistY)).EndInit();
      this.panelHistY.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelY)).EndInit();
      this.panelHistX.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolve)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHStep)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVStep)).EndInit();
      this.panelSolve.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.panelOriginal.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxOriginal;
    private System.Windows.Forms.PictureBox pictureBoxHistY;
    private System.Windows.Forms.Panel panelHistY;
    private System.Windows.Forms.Label labelErrorsX;
    private System.Windows.Forms.NumericUpDown numericUpDownLevelX;
    private System.Windows.Forms.NumericUpDown numericUpDownLevelY;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label labelErrorsY;
    private System.Windows.Forms.Panel panelHistX;
    private System.Windows.Forms.PictureBox pictureBoxHistX;
    private System.Windows.Forms.PictureBox pictureBoxSolve;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.NumericUpDown numericUpDownHStep;
    private System.Windows.Forms.NumericUpDown numericUpDownVStep;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.CheckBox checkBoxSolveZoom;
    private System.Windows.Forms.Panel panelSolve;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.CheckBox checkBoxOriginalZoom;
    private System.Windows.Forms.Panel panelOriginal;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
  }
}

