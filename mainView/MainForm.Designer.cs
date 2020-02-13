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
      this.checkBoxResultZoom = new System.Windows.Forms.CheckBox();
      this.panelSolve = new System.Windows.Forms.Panel();
      this.button7 = new System.Windows.Forms.Button();
      this.button8 = new System.Windows.Forms.Button();
      this.button9 = new System.Windows.Forms.Button();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button10 = new System.Windows.Forms.Button();
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
      this.SuspendLayout();
      // 
      // pictureBoxOriginal
      // 
      this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 12);
      this.pictureBoxOriginal.Name = "pictureBoxOriginal";
      this.pictureBoxOriginal.Size = new System.Drawing.Size(231, 454);
      this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxOriginal.TabIndex = 0;
      this.pictureBoxOriginal.TabStop = false;
      // 
      // pictureBoxHistY
      // 
      this.pictureBoxHistY.Location = new System.Drawing.Point(3, 3);
      this.pictureBoxHistY.Name = "pictureBoxHistY";
      this.pictureBoxHistY.Size = new System.Drawing.Size(242, 337);
      this.pictureBoxHistY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxHistY.TabIndex = 0;
      this.pictureBoxHistY.TabStop = false;
      // 
      // panelHistY
      // 
      this.panelHistY.AutoScroll = true;
      this.panelHistY.Controls.Add(this.pictureBoxHistY);
      this.panelHistY.Location = new System.Drawing.Point(249, 12);
      this.panelHistY.Name = "panelHistY";
      this.panelHistY.Size = new System.Drawing.Size(136, 454);
      this.panelHistY.TabIndex = 1;
      // 
      // labelErrorsX
      // 
      this.labelErrorsX.AutoSize = true;
      this.labelErrorsX.Location = new System.Drawing.Point(783, 503);
      this.labelErrorsX.Name = "labelErrorsX";
      this.labelErrorsX.Size = new System.Drawing.Size(52, 13);
      this.labelErrorsX.TabIndex = 4;
      this.labelErrorsX.Text = "---------------";
      // 
      // numericUpDownLevelX
      // 
      this.numericUpDownLevelX.Location = new System.Drawing.Point(888, 15);
      this.numericUpDownLevelX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownLevelX.Name = "numericUpDownLevelX";
      this.numericUpDownLevelX.Size = new System.Drawing.Size(68, 20);
      this.numericUpDownLevelX.TabIndex = 5;
      this.numericUpDownLevelX.ValueChanged += new System.EventHandler(this.numericUpDownLevelX_ValueChanged);
      // 
      // numericUpDownLevelY
      // 
      this.numericUpDownLevelY.Location = new System.Drawing.Point(888, 41);
      this.numericUpDownLevelY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownLevelY.Name = "numericUpDownLevelY";
      this.numericUpDownLevelY.Size = new System.Drawing.Size(68, 20);
      this.numericUpDownLevelY.TabIndex = 6;
      this.numericUpDownLevelY.ValueChanged += new System.EventHandler(this.numericUpDownLevelY_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(839, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Level X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(839, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Level Y";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(774, 134);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(89, 29);
      this.button1.TabIndex = 8;
      this.button1.Text = "Rescan";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // labelErrorsY
      // 
      this.labelErrorsY.AutoSize = true;
      this.labelErrorsY.Location = new System.Drawing.Point(783, 516);
      this.labelErrorsY.Name = "labelErrorsY";
      this.labelErrorsY.Size = new System.Drawing.Size(52, 13);
      this.labelErrorsY.TabIndex = 4;
      this.labelErrorsY.Text = "---------------";
      // 
      // panelHistX
      // 
      this.panelHistX.AutoScroll = true;
      this.panelHistX.Controls.Add(this.pictureBoxHistX);
      this.panelHistX.Location = new System.Drawing.Point(12, 472);
      this.panelHistX.Name = "panelHistX";
      this.panelHistX.Size = new System.Drawing.Size(707, 131);
      this.panelHistX.TabIndex = 2;
      // 
      // pictureBoxHistX
      // 
      this.pictureBoxHistX.Location = new System.Drawing.Point(3, 0);
      this.pictureBoxHistX.Name = "pictureBoxHistX";
      this.pictureBoxHistX.Size = new System.Drawing.Size(242, 259);
      this.pictureBoxHistX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxHistX.TabIndex = 0;
      this.pictureBoxHistX.TabStop = false;
      // 
      // pictureBoxSolve
      // 
      this.pictureBoxSolve.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxSolve.Location = new System.Drawing.Point(0, 0);
      this.pictureBoxSolve.Name = "pictureBoxSolve";
      this.pictureBoxSolve.Size = new System.Drawing.Size(329, 455);
      this.pictureBoxSolve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxSolve.TabIndex = 0;
      this.pictureBoxSolve.TabStop = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(14, 19);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(180, 31);
      this.button2.TabIndex = 8;
      this.button2.Text = "Horizontal step";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(14, 56);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(180, 31);
      this.button3.TabIndex = 8;
      this.button3.Text = "Vertical step";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(880, 134);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(89, 29);
      this.button4.TabIndex = 8;
      this.button4.Text = "Clear";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // numericUpDownHStep
      // 
      this.numericUpDownHStep.Location = new System.Drawing.Point(138, 96);
      this.numericUpDownHStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownHStep.Name = "numericUpDownHStep";
      this.numericUpDownHStep.Size = new System.Drawing.Size(56, 20);
      this.numericUpDownHStep.TabIndex = 5;
      // 
      // numericUpDownVStep
      // 
      this.numericUpDownVStep.Location = new System.Drawing.Point(138, 124);
      this.numericUpDownVStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownVStep.Name = "numericUpDownVStep";
      this.numericUpDownVStep.Size = new System.Drawing.Size(56, 20);
      this.numericUpDownVStep.TabIndex = 5;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(14, 93);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(118, 23);
      this.button5.TabIndex = 9;
      this.button5.Text = "Solve Line №";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(14, 122);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(118, 23);
      this.button6.TabIndex = 9;
      this.button6.Text = "Solve Column №";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // checkBoxResultZoom
      // 
      this.checkBoxResultZoom.AutoSize = true;
      this.checkBoxResultZoom.Location = new System.Drawing.Point(755, 11);
      this.checkBoxResultZoom.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxResultZoom.Name = "checkBoxResultZoom";
      this.checkBoxResultZoom.Size = new System.Drawing.Size(53, 17);
      this.checkBoxResultZoom.TabIndex = 10;
      this.checkBoxResultZoom.Text = "Zoom";
      this.checkBoxResultZoom.UseVisualStyleBackColor = true;
      this.checkBoxResultZoom.CheckedChanged += new System.EventHandler(this.checkBoxResultZoom_CheckedChanged);
      // 
      // panelSolve
      // 
      this.panelSolve.AutoScroll = true;
      this.panelSolve.Controls.Add(this.pictureBoxSolve);
      this.panelSolve.Location = new System.Drawing.Point(390, 11);
      this.panelSolve.Margin = new System.Windows.Forms.Padding(2);
      this.panelSolve.Name = "panelSolve";
      this.panelSolve.Size = new System.Drawing.Size(329, 455);
      this.panelSolve.TabIndex = 11;
      // 
      // button7
      // 
      this.button7.Location = new System.Drawing.Point(12, 19);
      this.button7.Name = "button7";
      this.button7.Size = new System.Drawing.Size(75, 23);
      this.button7.TabIndex = 12;
      this.button7.Text = "Init Test";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new System.EventHandler(this.button7_Click);
      // 
      // button8
      // 
      this.button8.Location = new System.Drawing.Point(117, 19);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(75, 23);
      this.button8.TabIndex = 12;
      this.button8.Text = "Start Test";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new System.EventHandler(this.button8_Click);
      // 
      // button9
      // 
      this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button9.Location = new System.Drawing.Point(774, 180);
      this.button9.Name = "button9";
      this.button9.Size = new System.Drawing.Size(195, 48);
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
      this.groupBox1.Location = new System.Drawing.Point(772, 255);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 159);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Solve by step";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.button7);
      this.groupBox2.Controls.Add(this.button8);
      this.groupBox2.Location = new System.Drawing.Point(774, 432);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(198, 58);
      this.groupBox2.TabIndex = 16;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Test";
      // 
      // button10
      // 
      this.button10.Location = new System.Drawing.Point(774, 93);
      this.button10.Name = "button10";
      this.button10.Size = new System.Drawing.Size(89, 29);
      this.button10.TabIndex = 17;
      this.button10.Text = "Load image";
      this.button10.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(993, 615);
      this.Controls.Add(this.button10);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.button9);
      this.Controls.Add(this.panelSolve);
      this.Controls.Add(this.checkBoxResultZoom);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.numericUpDownLevelY);
      this.Controls.Add(this.numericUpDownLevelX);
      this.Controls.Add(this.labelErrorsY);
      this.Controls.Add(this.labelErrorsX);
      this.Controls.Add(this.panelHistX);
      this.Controls.Add(this.panelHistY);
      this.Controls.Add(this.pictureBoxOriginal);
      this.Controls.Add(this.button4);
      this.Name = "MainForm";
      this.Text = "MainForm";
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
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.CheckBox checkBoxResultZoom;
    private System.Windows.Forms.Panel panelSolve;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button button10;
  }
}

