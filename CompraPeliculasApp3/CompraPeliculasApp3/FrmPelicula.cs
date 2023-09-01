using CompraPeliculasApp3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompraPeliculasApp3
{
    public partial class FrmPelicula : Form
    {
        PeliculaCompraContext context = new PeliculaCompraContext();
        public FrmPelicula()
        {
            InitializeComponent();
        }
        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.peliculas.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtnMovie_Click(object sender, EventArgs e)
        {
            double precio;
            if (!string.IsNullOrEmpty(txtNameMovie.Text) && !string.IsNullOrEmpty(txtPriceMovie.Text) && double.TryParse(txtPriceMovie.Text, out precio))
            {
                context.peliculas.Add(new Pelicula
                {
                    Name = txtNameMovie.Text,
                    Precio = precio
                });
                context.SaveChanges();
                dataGridView1.DataSource = context.peliculas.ToList();
            }

        }


    }
}
