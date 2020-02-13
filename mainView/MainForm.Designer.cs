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
      this.pictureBoxGreyscaled = new System.Windows.Forms.PictureBox();
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
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreyscaled)).BeginInit();
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
      this.SuspendLayout();
      // 
      // pictureBoxOriginal
      // 
      this.pictureBoxOriginal.Location = new System.Drawing.Point(874, 21);
      this.pictureBoxOriginal.Name = "pictureBoxOriginal";
      this.pictureBoxOriginal.Size = new System.Drawing.Size(107, 155);
      this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxOriginal.TabIndex = 0;
      this.pictureBoxOriginal.TabStop = false;
      // 
      // pictureBoxGreyscaled
      // 
      this.pictureBoxGreyscaled.Location = new System.Drawing.Point(35, 21);
      this.pictureBoxGreyscaled.Name = "pictureBoxGreyscaled";
      this.pictureBoxGreyscaled.Size = new System.Drawing.Size(208, 340);
      this.pictureBoxGreyscaled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxGreyscaled.TabIndex = 0;
      this.pictureBoxGreyscaled.TabStop = false;
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
      this.panelHistY.Location = new System.Drawing.Point(249, 21);
      this.panelHistY.Name = "panelHistY";
      this.panelHistY.Size = new System.Drawing.Size(208, 340);
      this.panelHistY.TabIndex = 1;
      // 
      // labelErrorsX
      // 
      this.labelErrorsX.AutoSize = true;
      this.labelErrorsX.Location = new System.Drawing.Point(779, 195);
      this.labelErrorsX.Name = "labelErrorsX";
      this.labelErrorsX.Size = new System.Drawing.Size(52, 13);
      this.labelErrorsX.TabIndex = 4;
      this.labelErrorsX.Text = "---------------";
      // 
      // numericUpDownLevelX
      // 
      this.numericUpDownLevelX.Location = new System.Drawing.Point(913, 235);
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
      this.numericUpDownLevelY.Location = new System.Drawing.Point(913, 270);
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
      this.label1.Location = new System.Drawing.Point(782, 241);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Level X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(782, 277);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Level Y";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(810, 296);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(113, 31);
      this.button1.TabIndex = 8;
      this.button1.Text = "Redraw";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // labelErrorsY
      // 
      this.labelErrorsY.AutoSize = true;
      this.labelErrorsY.Location = new System.Drawing.Point(779, 208);
      this.labelErrorsY.Name = "labelErrorsY";
      this.labelErrorsY.Size = new System.Drawing.Size(52, 13);
      this.labelErrorsY.TabIndex = 4;
      this.labelErrorsY.Text = "---------------";
      // 
      // panelHistX
      // 
      this.panelHistX.AutoScroll = true;
      this.panelHistX.Controls.Add(this.pictureBoxHistX);
      this.panelHistX.Location = new System.Drawing.Point(35, 367);
      this.panelHistX.Name = "panelHistX";
      this.panelHistX.Size = new System.Drawing.Size(707, 216);
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
      this.pictureBoxSolve.Size = new System.Drawing.Size(302, 340);
      this.pictureBoxSolve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBoxSolve.TabIndex = 0;
      this.pictureBoxSolve.TabStop = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(759, 446);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(88, 31);
      this.button2.TabIndex = 8;
      this.button2.Text = "Horizontal step";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(759, 483);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(88, 31);
      this.button3.TabIndex = 8;
      this.button3.Text = "Vertical step";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(759, 393);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(113, 31);
      this.button4.TabIndex = 8;
      this.button4.Text = "Clear Playarea";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // numericUpDownHStep
      // 
      this.numericUpDownHStep.Location = new System.Drawing.Point(874, 453);
      this.numericUpDownHStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownHStep.Name = "numericUpDownHStep";
      this.numericUpDownHStep.Size = new System.Drawing.Size(43, 20);
      this.numericUpDownHStep.TabIndex = 5;
      // 
      // numericUpDownVStep
      // 
      this.numericUpDownVStep.Location = new System.Drawing.Point(874, 490);
      this.numericUpDownVStep.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.numericUpDownVStep.Name = "numericUpDownVStep";
      this.numericUpDownVStep.Size = new System.Drawing.Size(43, 20);
      this.numericUpDownVStep.TabIndex = 5;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(934, 450);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(47, 23);
      this.button5.TabIndex = 9;
      this.button5.Text = "HStep";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(934, 487);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(47, 23);
      this.button6.TabIndex = 9;
      this.button6.Text = "VStep";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // checkBoxResultZoom
      // 
      this.checkBoxResultZoom.AutoSize = true;
      this.checkBoxResultZoom.Location = new System.Drawing.Point(784, 20);
      this.checkBoxResultZoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
      this.panelSolve.Location = new System.Drawing.Point(471, 20);
      this.panelSolve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.panelSolve.Name = "panelSolve";
      this.panelSolve.Size = new System.Drawing.Size(302, 340);
      this.panelSolve.TabIndex = 11;
      // 
      // button7
      // 
      this.button7.Location = new System.Drawing.Point(773, 549);
      this.button7.Name = "button7";
      this.button7.Size = new System.Drawing.Size(75, 23);
      this.button7.TabIndex = 12;
      this.button7.Text = "Init Test";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new System.EventHandler(this.button7_Click);
      // 
      // button8
      // 
      this.button8.Location = new System.Drawing.Point(854, 549);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(75, 23);
      this.button8.TabIndex = 12;
      this.button8.Text = "Start Test";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new System.EventHandler(this.button8_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(993, 615);
      this.Controls.Add(this.button8);
      this.Controls.Add(this.button7);
      this.Controls.Add(this.panelSolve);
      this.Controls.Add(this.checkBoxResultZoom);
      this.Controls.Add(this.button6);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.numericUpDownLevelY);
      this.Controls.Add(this.numericUpDownVStep);
      this.Controls.Add(this.numericUpDownHStep);
      this.Controls.Add(this.numericUpDownLevelX);
      this.Controls.Add(this.labelErrorsY);
      this.Controls.Add(this.labelErrorsX);
      this.Controls.Add(this.panelHistX);
      this.Controls.Add(this.panelHistY);
      this.Controls.Add(this.pictureBoxGreyscaled);
      this.Controls.Add(this.pictureBoxOriginal);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button2);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreyscaled)).EndInit();
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
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxOriginal;
    private System.Windows.Forms.PictureBox pictureBoxGreyscaled;
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
  }
}

