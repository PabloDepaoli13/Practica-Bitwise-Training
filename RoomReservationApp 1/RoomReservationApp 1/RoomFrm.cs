using RoomReservationApp_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationApp_1
{
    public partial class RoomFrm : Form
    {
        RoomReservationContext _context = new RoomReservationContext();
        public RoomFrm()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double price;
            if (!string.IsNullOrEmpty(AddPrice.Text) && !string.IsNullOrEmpty(txtAddName.Text) && double.TryParse(AddPrice.Text, out price))
            {
                _context.Rooms.Add(new Rooms
                {
                    Name = txtAddName.Text,
                    Price = price,
                    IsActive= true

                });
                _context.SaveChanges();
            }
            dataGridView1.DataSource = _context.Rooms.ToList();
        }

        private void RoomFrm_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Rooms.ToList();
        }

        private void txtAddName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
