using RoomReservationApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationApp2
{
    public partial class FrmPeliculas : Form
    {
        PeliculaCompraContext context = new PeliculaCompraContext();
        public FrmPeliculas()
        {
            InitializeComponent();
        }

        private void FrmPeliculas_Load(object sender, EventArgs e)
        {
            dataMovieView.DataSource = context.Peliculas.ToList();  
        }

        private void addMovieBtn_Click(object sender, EventArgs e)
        {
            double precio;
            if (!string.IsNullOrEmpty(textNameMovie.Text) && !string.IsNullOrEmpty(textPriceMovie.Text) && double.TryParse(textPriceMovie.Text, out precio)) 
            {
                context.Peliculas.Add(new Peliculas
                {
                    Name = textNameMovie.Text,
                    PrecioEntrada = precio
                });
                context.SaveChanges();
                dataMovieView.DataSource = context.Peliculas.ToList();
            }
            
        }
    }
}
