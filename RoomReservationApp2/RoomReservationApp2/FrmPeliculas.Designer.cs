namespace RoomReservationApp2
{
    partial class FrmPeliculas
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
            this.labelNameMovie = new System.Windows.Forms.Label();
            this.textNameMovie = new System.Windows.Forms.TextBox();
            this.textPriceMovie = new System.Windows.Forms.TextBox();
            this.labelPriceMovie = new System.Windows.Forms.Label();
            this.addMovieBtn = new System.Windows.Forms.Button();
            this.dataMovieView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMovieView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addMovieBtn);
            this.groupBox1.Controls.Add(this.textPriceMovie);
            this.groupBox1.Controls.Add(this.labelPriceMovie);
            this.groupBox1.Controls.Add(this.textNameMovie);
            this.groupBox1.Controls.Add(this.labelNameMovie);
            this.groupBox1.Location = new System.Drawing.Point(527, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // labelNameMovie
            // 
            this.labelNameMovie.AutoSize = true;
            this.labelNameMovie.Location = new System.Drawing.Point(7, 20);
            this.labelNameMovie.Name = "labelNameMovie";
            this.labelNameMovie.Size = new System.Drawing.Size(35, 13);
            this.labelNameMovie.TabIndex = 0;
            this.labelNameMovie.Text = "Name";
            // 
            // textNameMovie
            // 
            this.textNameMovie.Location = new System.Drawing.Point(48, 17);
            this.textNameMovie.Name = "textNameMovie";
            this.textNameMovie.Size = new System.Drawing.Size(145, 20);
            this.textNameMovie.TabIndex = 1;
            // 
            // textPriceMovie
            // 
            this.textPriceMovie.Location = new System.Drawing.Point(48, 40);
            this.textPriceMovie.Name = "textPriceMovie";
            this.textPriceMovie.Size = new System.Drawing.Size(145, 20);
            this.textPriceMovie.TabIndex = 3;
            // 
            // labelPriceMovie
            // 
            this.labelPriceMovie.AutoSize = true;
            this.labelPriceMovie.Location = new System.Drawing.Point(7, 43);
            this.labelPriceMovie.Name = "labelPriceMovie";
            this.labelPriceMovie.Size = new System.Drawing.Size(31, 13);
            this.labelPriceMovie.TabIndex = 2;
            this.labelPriceMovie.Text = "Price";
            // 
            // addMovieBtn
            // 
            this.addMovieBtn.Location = new System.Drawing.Point(118, 66);
            this.addMovieBtn.Name = "addMovieBtn";
            this.addMovieBtn.Size = new System.Drawing.Size(75, 23);
            this.addMovieBtn.TabIndex = 4;
            this.addMovieBtn.Text = "Add";
            this.addMovieBtn.UseVisualStyleBackColor = true;
            this.addMovieBtn.Click += new System.EventHandler(this.addMovieBtn_Click);
            // 
            // dataMovieView
            // 
            this.dataMovieView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMovieView.Location = new System.Drawing.Point(90, 241);
            this.dataMovieView.Name = "dataMovieView";
            this.dataMovieView.Size = new System.Drawing.Size(630, 150);
            this.dataMovieView.TabIndex = 1;
            // 
            // FrmPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataMovieView);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPeliculas";
            this.Text = "FrmPeliculas";
            this.Load += new System.EventHandler(this.FrmPeliculas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMovieView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNameMovie;
        private System.Windows.Forms.TextBox textNameMovie;
        private System.Windows.Forms.Button addMovieBtn;
        private System.Windows.Forms.TextBox textPriceMovie;
        private System.Windows.Forms.Label labelPriceMovie;
        private System.Windows.Forms.DataGridView dataMovieView;
    }
}