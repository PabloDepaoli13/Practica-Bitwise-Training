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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomFrm roomFrm = new RoomFrm();
            roomFrm.ShowDialog();
        }
    }
}
