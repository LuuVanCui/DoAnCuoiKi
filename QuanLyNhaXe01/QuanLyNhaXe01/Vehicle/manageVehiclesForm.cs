using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhaXe01.Vehicle
{
    public partial class manageVehiclesForm : Form
    {
        public manageVehiclesForm()
        {
            InitializeComponent();
        }

        Vehicle vehicle = new Vehicle();

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editVehicleForm editForm = new editVehicleForm();
            editForm.ShowDialog(this);
        }

        private void textBoxSearchLicenPlate_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT *FROM Xe WHERE CONCAT(MaTheXe, LoaiXe, BienSo, ThoiGianVao, Slot) LIKE '%" + textBoxSearchLicenPlate.Text + "%'");
            dataGridVManageVehicle.DataSource = vehicle.getVehicle(command);
        }

        private void manageVehiclesForm_Load(object sender, EventArgs e)
        {
            DataTable dt = vehicle.getTypeVehicle();
            dt.Rows.Add(new Object[]{
                "Tat Ca"
            });
            comboBoxTypeVehicle.DataSource = dt;
            comboBoxTypeVehicle.ValueMember = "LoaiXe";
            comboBoxTypeVehicle.DisplayMember = "LoaiXe";
            fillGrid();
         //   makeUpGridForAllVehicle();
        }

        void fillGrid()
        {
            if (comboBoxTypeVehicle.Text == "Xe May")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe, LoaiXe, NguoiGui, AnhXe, ThoiGianVao, Slot FROM dbo.Xe WHERE LoaiXe = 'Xe May'"));
            }
            else if (comboBoxTypeVehicle.Text == "Xe Dap")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT MaTheXe, LoaiXe, NguoiGui, AnhXe, ThoiGianVao, Slot FROM dbo.Xe WHERE LoaiXe = 'Xe Dap'"));
            }
            else if (comboBoxTypeVehicle.Text == "Xe Hoi")
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT *FROM Xe  WHERE LoaiXe = 'Xe Hoi'"));
            }
            else
            {
                dataGridVManageVehicle.DataSource = vehicle.getVehicle(new SqlCommand("SELECT *FROM Xe"));
            }
        }

        private void comboBoxTypeVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addVehicleForm addForm = new addVehicleForm();
            addForm.ShowDialog(this);
        }

        void makeUpGridForAllVehicle()
        {
            dataGridVManageVehicle.ReadOnly = true;

            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol6 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol7 = new DataGridViewImageColumn();

            dataGridVManageVehicle.RowTemplate.Height = 80;

       //     dataGridVManageVehicle.DataSource = student.getStudents(command);

            picCol2 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[2];

            picCol3 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[3];

            picCol6 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[6];

            picCol7 = (DataGridViewImageColumn)dataGridVManageVehicle.Columns[7];

            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol6.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol7.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridVManageVehicle.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridVManageVehicle.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("Do you want to detele this vehicle", "Delete Vehicle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    vehicle.deleteVehicle(id);
                    fillGrid();
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
