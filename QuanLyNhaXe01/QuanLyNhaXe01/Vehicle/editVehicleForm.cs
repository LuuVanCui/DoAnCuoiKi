using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXe01.Vehicle
{
    public partial class editVehicleForm : Form
    {
        public editVehicleForm()
        {
            InitializeComponent();
        }

        private void editVehicleForm_Load(object sender, EventArgs e)
        {
            manageVehiclesForm manageForm = new manageVehiclesForm();
        }
    }
}
