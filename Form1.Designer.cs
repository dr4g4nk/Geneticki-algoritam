namespace mvi
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.min = new System.Windows.Forms.RadioButton();
            this.max = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.precision = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.NumericUpDown();
            this.probCo = new System.Windows.Forms.NumericUpDown();
            this.probMut = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.precision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probMut)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Preciznost:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // min
            // 
            this.min.AutoSize = true;
            this.min.Checked = true;
            this.min.Location = new System.Drawing.Point(40, 344);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(51, 21);
            this.min.TabIndex = 5;
            this.min.TabStop = true;
            this.min.Text = "Min";
            this.min.UseVisualStyleBackColor = true;
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.Location = new System.Drawing.Point(163, 344);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(54, 21);
            this.max.TabIndex = 6;
            this.max.Text = "Max";
            this.max.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vjerovatnoca rekombinacije[0-1]:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vjerovatnoca mutacije[0-1]:";
            // 
            // precision
            // 
            this.precision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.precision.Location = new System.Drawing.Point(297, 43);
            this.precision.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.precision.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.precision.Name = "precision";
            this.precision.Size = new System.Drawing.Size(81, 22);
            this.precision.TabIndex = 0;
            this.precision.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Velicina populacije:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "10";
            // 
            // size
            // 
            this.size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.size.Location = new System.Drawing.Point(270, 111);
            this.size.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(108, 22);
            this.size.TabIndex = 1;
            this.size.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Broj iteracija:";
            // 
            // iterations
            // 
            this.iterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iterations.Location = new System.Drawing.Point(270, 255);
            this.iterations.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.iterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(108, 22);
            this.iterations.TabIndex = 4;
            this.iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // probCo
            // 
            this.probCo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probCo.DecimalPlaces = 2;
            this.probCo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.probCo.Location = new System.Drawing.Point(270, 161);
            this.probCo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probCo.Name = "probCo";
            this.probCo.Size = new System.Drawing.Size(108, 22);
            this.probCo.TabIndex = 2;
            this.probCo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // probMut
            // 
            this.probMut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probMut.DecimalPlaces = 2;
            this.probMut.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.probMut.Location = new System.Drawing.Point(270, 205);
            this.probMut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probMut.Name = "probMut";
            this.probMut.Size = new System.Drawing.Size(108, 22);
            this.probMut.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(424, 512);
            this.Controls.Add(this.probMut);
            this.Controls.Add(this.probCo);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.size);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.precision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.max);
            this.Controls.Add(this.min);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Genenticki Algoritami";
            ((System.ComponentModel.ISupportInitialize)(this.precision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probMut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton min;
        private System.Windows.Forms.RadioButton max;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown precision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown size;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown iterations;
        private System.Windows.Forms.NumericUpDown probCo;
        private System.Windows.Forms.NumericUpDown probMut;
    }
}

