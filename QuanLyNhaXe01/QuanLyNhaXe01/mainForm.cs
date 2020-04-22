using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaXe01.Vehicle;

namespace QuanLyNhaXe01
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void manageVerhicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manageVehiclesForm manageForm = new manageVehiclesForm();
            manageForm.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printVehiclesForm printForm = new printVehiclesForm();
            printForm.Show(this);
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addVehicleForm addForm = new addVehicleForm();
            addForm.Show(this);
        }

        private void deleteVehicleByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
