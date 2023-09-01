using BuyMovieApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuyMovieApp
{
    public partial class FrmMovies : Form
    {
        PeliculasDBContext context = new PeliculasDBContext();
        public FrmMovies()
        {
            InitializeComponent();
        }
        private void FrmMovies_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.peliculas.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double precio;
            if (!string.IsNullOrEmpty(txtNameMovie.Text) && !string.IsNullOrEmpty(txtPriceMovie.Text) && double.TryParse(txtPriceMovie.Text, out precio))
            {
                context.peliculas.Add(new Peliculas
                {
                    Name = txtNameMovie.Text,
                    Price = precio
                });
                context.SaveChanges();
                dataGridView1.DataSource = context.peliculas.ToList();
            }

        }

    }

        
    }
}
