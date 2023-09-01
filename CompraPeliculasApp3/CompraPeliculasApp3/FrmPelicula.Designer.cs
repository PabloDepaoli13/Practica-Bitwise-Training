namespace CompraPeliculasApp3
{
    partial class FrmPelicula
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddBtnMovie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameMovie = new System.Windows.Forms.TextBox();
            this.txtPriceMovie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPriceMovie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNameMovie);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AddBtnMovie);
            this.groupBox1.Location = new System.Drawing.Point(474, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(704, 190);
            this.dataGridView1.TabIndex = 1;
            // 
            // AddBtnMovie
            // 
            this.AddBtnMovie.Location = new System.Drawing.Point(121, 75);
            this.AddBtnMovie.Name = "AddBtnMovie";
            this.AddBtnMovie.Size = new System.Drawing.Size(75, 23);
            this.AddBtnMovie.TabIndex = 0;
            this.AddBtnMovie.Text = "Add";
            this.AddBtnMovie.UseVisualStyleBackColor = true;
            this.AddBtnMovie.Click += new System.EventHandler(this.AddBtnMovie_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNameMovie
            // 
            this.txtNameMovie.Location = new System.Drawing.Point(51, 23);
            this.txtNameMovie.Name = "txtNameMovie";
            this.txtNameMovie.Size = new System.Drawing.Size(145, 20);
            this.txtNameMovie.TabIndex = 2;
            // 
            // txtPriceMovie
            // 
            this.txtPriceMovie.Location = new System.Drawing.Point(51, 49);
            this.txtPriceMovie.Name = "txtPriceMovie";
            this.txtPriceMovie.Size = new System.Drawing.Size(145, 20);
            this.txtPriceMovie.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price";
            // 
            // FrmPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPelicula";
            this.Text = "FrmPelicula";
            this.Load += new System.EventHandler(this.FrmPelicula_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNameMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddBtnMovie;
        private System.Windows.Forms.TextBox txtPriceMovie;
        private System.Windows.Forms.Label label2;
    }
}