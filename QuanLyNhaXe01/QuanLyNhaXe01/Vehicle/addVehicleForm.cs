using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXe01.Vehicle
{
    public partial class addVehicleForm : Form
    {
        public addVehicleForm()
        {
            InitializeComponent();
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            try
            {
                string id = textBoxCardID.Text;
                string type = "Xe May";
                if (radioButtonBike.Checked)
                    type = "Xe Dap";
                else if (radioButtonCar.Checked)
                    type = "Xe Hoi";
                MemoryStream model_pic = new MemoryStream();
                MemoryStream user_pic = new MemoryStream();
                MemoryStream license_pic = new MemoryStream();
                MemoryStream vehicle_pic = new MemoryStream();
                pictureBoxModel.Image.Save(model_pic, pictureBoxModel.Image.RawFormat);
                pictureBoxUser.Image.Save(user_pic, pictureBoxUser.Image.RawFormat);
                pictureBoxLicensePlate.Image.Save(license_pic, pictureBoxLicensePlate.Image.RawFormat);
                pictureBoxVehiclePicture.Image.Save(vehicle_pic, pictureBoxVehiclePicture.Image.RawFormat);
                DateTime inTime = dateTimePickerInTime.Value;
                vehicle.insertVehicle(id, type, license_pic, user_pic, model_pic, vehicle_pic, inTime);
               
                if (radioButtonBike.Checked)

                MessageBox.Show("New Vehicle Added", "Add Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Vehice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonLoadModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxModel.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadUser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxUser.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadLicensePlate_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxLicensePlate.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonLoadVehiclePictrue_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxVehiclePicture.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
