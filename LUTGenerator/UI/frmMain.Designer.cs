namespace Petrofsky.Photography.LUTGenerator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dlgGenerateReference = new System.Windows.Forms.SaveFileDialog();
            this.dlgLoadReference = new System.Windows.Forms.OpenFileDialog();
            this.tabReference = new System.Windows.Forms.TabPage();
            this.chkUseScript = new System.Windows.Forms.CheckBox();
            this.btnCreateLUT = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctSample = new System.Windows.Forms.PictureBox();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.numGreenIndex = new System.Windows.Forms.NumericUpDown();
            this.numBlueIndex = new System.Windows.Forms.NumericUpDown();
            this.numRedIndex = new System.Windows.Forms.NumericUpDown();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.numBlockSize = new System.Windows.Forms.NumericUpDown();
            this.numDimension = new System.Windows.Forms.NumericUpDown();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.lblDimension = new System.Windows.Forms.Label();
            this.tabScripting = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.dlgCreateLUT = new System.Windows.Forms.SaveFileDialog();
            this.dlgLoadScript = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveScript = new System.Windows.Forms.SaveFileDialog();
            this.tabReference.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreenIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlueIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRedIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimension)).BeginInit();
            this.tabScripting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgGenerateReference
            // 
            this.dlgGenerateReference.DefaultExt = "tiff";
            this.dlgGenerateReference.Filter = "\"TIFF Files (*.tiff)|*.tiff;\"";
            this.dlgGenerateReference.Title = "Save reference file as...";
            // 
            // dlgLoadReference
            // 
            this.dlgLoadReference.DefaultExt = "tiff";
            this.dlgLoadReference.FileName = "openFileDialog1";
            this.dlgLoadReference.Filter = "TIFF files (*.tiff)|*.tiff;";
            this.dlgLoadReference.Title = "Open reference image...";
            // 
            // tabReference
            // 
            this.tabReference.AutoScroll = true;
            this.tabReference.BackColor = System.Drawing.Color.Transparent;
            this.tabReference.Controls.Add(this.chkUseScript);
            this.tabReference.Controls.Add(this.btnCreateLUT);
            this.tabReference.Controls.Add(this.groupBox1);
            this.tabReference.Controls.Add(this.btnLoad);
            this.tabReference.Controls.Add(this.btnGenerate);
            this.tabReference.Controls.Add(this.numBlockSize);
            this.tabReference.Controls.Add(this.numDimension);
            this.tabReference.Controls.Add(this.lblBlockSize);
            this.tabReference.Controls.Add(this.lblDimension);
            this.tabReference.Location = new System.Drawing.Point(4, 22);
            this.tabReference.Name = "tabReference";
            this.tabReference.Padding = new System.Windows.Forms.Padding(3);
            this.tabReference.Size = new System.Drawing.Size(537, 316);
            this.tabReference.TabIndex = 0;
            this.tabReference.Text = "Reference";
            // 
            // chkUseScript
            // 
            this.chkUseScript.AutoSize = true;
            this.chkUseScript.Enabled = false;
            this.chkUseScript.Location = new System.Drawing.Point(424, 77);
            this.chkUseScript.Name = "chkUseScript";
            this.chkUseScript.Size = new System.Drawing.Size(82, 17);
            this.chkUseScript.TabIndex = 9;
            this.chkUseScript.Text = "Apply Script";
            this.chkUseScript.UseVisualStyleBackColor = true;
            // 
            // btnCreateLUT
            // 
            this.btnCreateLUT.Enabled = false;
            this.btnCreateLUT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateLUT.Location = new System.Drawing.Point(311, 65);
            this.btnCreateLUT.Name = "btnCreateLUT";
            this.btnCreateLUT.Size = new System.Drawing.Size(107, 37);
            this.btnCreateLUT.TabIndex = 8;
            this.btnCreateLUT.Text = "&Create LUT";
            this.btnCreateLUT.UseVisualStyleBackColor = true;
            this.btnCreateLUT.Click += new System.EventHandler(this.btnCreateLUT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.pctSample);
            this.groupBox1.Controls.Add(this.txtBlue);
            this.groupBox1.Controls.Add(this.txtGreen);
            this.groupBox1.Controls.Add(this.txtRed);
            this.groupBox1.Controls.Add(this.numGreenIndex);
            this.groupBox1.Controls.Add(this.numBlueIndex);
            this.groupBox1.Controls.Add(this.numRedIndex);
            this.groupBox1.Location = new System.Drawing.Point(29, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Samples";
            // 
            // pctSample
            // 
            this.pctSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctSample.Enabled = false;
            this.pctSample.Location = new System.Drawing.Point(157, 37);
            this.pctSample.Name = "pctSample";
            this.pctSample.Size = new System.Drawing.Size(204, 93);
            this.pctSample.TabIndex = 7;
            this.pctSample.TabStop = false;
            // 
            // txtBlue
            // 
            this.txtBlue.Enabled = false;
            this.txtBlue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlue.Location = new System.Drawing.Point(87, 103);
            this.txtBlue.MaxLength = 3;
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.ReadOnly = true;
            this.txtBlue.Size = new System.Drawing.Size(34, 27);
            this.txtBlue.TabIndex = 6;
            this.txtBlue.Text = "255";
            // 
            // txtGreen
            // 
            this.txtGreen.Enabled = false;
            this.txtGreen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGreen.Location = new System.Drawing.Point(87, 70);
            this.txtGreen.MaxLength = 3;
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.ReadOnly = true;
            this.txtGreen.Size = new System.Drawing.Size(34, 27);
            this.txtGreen.TabIndex = 5;
            this.txtGreen.Text = "255";
            // 
            // txtRed
            // 
            this.txtRed.Enabled = false;
            this.txtRed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRed.Location = new System.Drawing.Point(87, 37);
            this.txtRed.MaxLength = 3;
            this.txtRed.Name = "txtRed";
            this.txtRed.ReadOnly = true;
            this.txtRed.Size = new System.Drawing.Size(34, 27);
            this.txtRed.TabIndex = 4;
            this.txtRed.Text = "255";
            // 
            // numGreenIndex
            // 
            this.numGreenIndex.AutoSize = true;
            this.numGreenIndex.Enabled = false;
            this.numGreenIndex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGreenIndex.Location = new System.Drawing.Point(20, 70);
            this.numGreenIndex.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numGreenIndex.Name = "numGreenIndex";
            this.numGreenIndex.Size = new System.Drawing.Size(49, 27);
            this.numGreenIndex.TabIndex = 3;
            this.numGreenIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGreenIndex.ValueChanged += new System.EventHandler(this.numIndex_ValueChanged);
            // 
            // numBlueIndex
            // 
            this.numBlueIndex.AutoSize = true;
            this.numBlueIndex.Enabled = false;
            this.numBlueIndex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBlueIndex.Location = new System.Drawing.Point(20, 103);
            this.numBlueIndex.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numBlueIndex.Name = "numBlueIndex";
            this.numBlueIndex.Size = new System.Drawing.Size(49, 27);
            this.numBlueIndex.TabIndex = 2;
            this.numBlueIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBlueIndex.ValueChanged += new System.EventHandler(this.numIndex_ValueChanged);
            // 
            // numRedIndex
            // 
            this.numRedIndex.AutoSize = true;
            this.numRedIndex.Enabled = false;
            this.numRedIndex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRedIndex.Location = new System.Drawing.Point(20, 37);
            this.numRedIndex.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numRedIndex.Name = "numRedIndex";
            this.numRedIndex.Size = new System.Drawing.Size(49, 27);
            this.numRedIndex.TabIndex = 1;
            this.numRedIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRedIndex.ValueChanged += new System.EventHandler(this.numIndex_ValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(311, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(107, 37);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(424, 22);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(107, 37);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // numBlockSize
            // 
            this.numBlockSize.AutoSize = true;
            this.numBlockSize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBlockSize.Location = new System.Drawing.Point(247, 58);
            this.numBlockSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBlockSize.Name = "numBlockSize";
            this.numBlockSize.Size = new System.Drawing.Size(49, 27);
            this.numBlockSize.TabIndex = 1;
            this.numBlockSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBlockSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numDimension
            // 
            this.numDimension.AutoSize = true;
            this.numDimension.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDimension.Location = new System.Drawing.Point(247, 20);
            this.numDimension.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numDimension.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDimension.Name = "numDimension";
            this.numDimension.Size = new System.Drawing.Size(49, 27);
            this.numDimension.TabIndex = 0;
            this.numDimension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDimension.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockSize.Location = new System.Drawing.Point(25, 60);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(168, 19);
            this.lblBlockSize.TabIndex = 1;
            this.lblBlockSize.Text = "Sample Block Dimension";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimension.Location = new System.Drawing.Point(25, 22);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(126, 19);
            this.lblDimension.TabIndex = 0;
            this.lblDimension.Text = "Lattice Dimension";
            // 
            // tabScripting
            // 
            this.tabScripting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabScripting.Controls.Add(this.tabReference);
            this.tabScripting.Controls.Add(this.tabPage1);
            this.tabScripting.Location = new System.Drawing.Point(12, 12);
            this.tabScripting.Name = "tabScripting";
            this.tabScripting.SelectedIndex = 0;
            this.tabScripting.Size = new System.Drawing.Size(545, 342);
            this.tabScripting.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnSaveScript);
            this.tabPage1.Controls.Add(this.btnLoadScript);
            this.tabPage1.Controls.Add(this.txtScript);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(537, 316);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Scripting";
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveScript.Location = new System.Drawing.Point(119, 6);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(107, 37);
            this.btnSaveScript.TabIndex = 5;
            this.btnSaveScript.Text = "Save";
            this.btnSaveScript.UseVisualStyleBackColor = true;
            this.btnSaveScript.Click += new System.EventHandler(this.btnSaveScript_Click);
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadScript.Location = new System.Drawing.Point(6, 6);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(107, 37);
            this.btnLoadScript.TabIndex = 4;
            this.btnLoadScript.Text = "Open";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(6, 49);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(521, 261);
            this.txtScript.TabIndex = 3;
            // 
            // dlgCreateLUT
            // 
            this.dlgCreateLUT.DefaultExt = "cube";
            this.dlgCreateLUT.Filter = "CUBE files (*.cube)|*.cube;";
            this.dlgCreateLUT.Title = "Save 3D lut file as...";
            // 
            // dlgLoadScript
            // 
            this.dlgLoadScript.DefaultExt = "py";
            this.dlgLoadScript.FileName = "openFileDialog1";
            this.dlgLoadScript.Filter = "Python Script (*.py)|*.py;";
            this.dlgLoadScript.Title = "Select script to load...";
            // 
            // dlgSaveScript
            // 
            this.dlgSaveScript.DefaultExt = "py";
            this.dlgSaveScript.Filter = "Python Scripts (*.py)|*.py;";
            this.dlgSaveScript.Title = "Save script as...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 366);
            this.Controls.Add(this.tabScripting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "LUTGenerator";
            this.tabReference.ResumeLayout(false);
            this.tabReference.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreenIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlueIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRedIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimension)).EndInit();
            this.tabScripting.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog dlgGenerateReference;
        private System.Windows.Forms.OpenFileDialog dlgLoadReference;
        private System.Windows.Forms.TabPage tabReference;
        private System.Windows.Forms.Button btnCreateLUT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctSample;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.NumericUpDown numGreenIndex;
        private System.Windows.Forms.NumericUpDown numBlueIndex;
        private System.Windows.Forms.NumericUpDown numRedIndex;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numBlockSize;
        private System.Windows.Forms.NumericUpDown numDimension;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.TabControl tabScripting;
        private System.Windows.Forms.SaveFileDialog dlgCreateLUT;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog dlgLoadScript;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.SaveFileDialog dlgSaveScript;
        private System.Windows.Forms.CheckBox chkUseScript;
    }
}

