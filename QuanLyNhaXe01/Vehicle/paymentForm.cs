﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXe01
{
    public partial class paymentForm : Form
    {
        public paymentForm()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();

        private string id;

        public paymentForm(string ID) : this()
        {
            id = ID;
        }
        private void paymentForm_Load(object sender, EventArgs e)
        {

            paymentForm pay = new paymentForm();
            SqlCommand command = new SqlCommand("SELECT MaTheXe, LoaiXe, ThoiGianVao, AnhXe FROM Xe WHERE MaTheXe = " + id);
            DataTable table = vehicle.getVehicle(command);

            if (table.Rows.Count > 0)
            {
                labelCardID.Text = table.Rows[0]["MaTheXe"].ToString();
                labelTypeOfVehicle.Text = table.Rows[0]["LoaiXe"].ToString();
                labelInTime.Text = table.Rows[0]["ThoiGianVao"].ToString();


                //byte[] pic = (byte[])table.Rows[0]["AnhXe"];
                //MemoryStream AnhXe = new MemoryStream(pic);
                //pictureBoxVehiclePicture.Image = Image.FromStream(AnhXe);

            }

            // DateTime time = DateTime.Parse(labelInTime.Text);


        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                string CardID = labelCardID.Text.Trim();
                if (MessageBox.Show("Do you want to pay this vehicle?", "Pay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (vehicle.updateVehicleOut(CardID))
                    {
                        MessageBox.Show("Pay sucessful!", "Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can't Pay", "Pay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
