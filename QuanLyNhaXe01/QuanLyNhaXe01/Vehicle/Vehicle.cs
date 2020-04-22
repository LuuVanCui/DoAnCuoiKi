using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe01.Vehicle
{
    class Vehicle
    {
        MyDB mydb = new MyDB();

        //MaTheXe, LoaiXe,BienSo,NguoiGui,HieuXe,AnhXe,ThoiGianVao,Slot
        public bool insertVehicle(string MaTheXe, string LoaiXe, MemoryStream BienSo, MemoryStream NguoiGui, MemoryStream HieuXe,
                                    MemoryStream AnhXe, DateTime ThoiGianVao)
        {
            // SqlCommand command = new SqlCommand("Insert INTO Table_Vehicle(License_plate,Type_of_vehicle, Picture,In_time,Out_time,Payment )" +
            //   "Values(@id, @type,@pic,@inTime,@outTime,@payment )", mydb.getConnection);
            SqlCommand command = new SqlCommand("Insert INTO Xe(MaTheXe, LoaiXe,BienSo,NguoiGui,HieuXe,AnhXe,ThoiGianVao)" +
                "Values(@ma,@loai,@bienso,@nguoigui,@hieuxe,@anhxe,@time)", mydb.getConnection);

            command.Parameters.Add("@ma", System.Data.SqlDbType.Char).Value = MaTheXe;
            command.Parameters.Add("@loai", System.Data.SqlDbType.NVarChar).Value = LoaiXe;
            command.Parameters.Add("@bienso", System.Data.SqlDbType.Image).Value = BienSo.ToArray();
            command.Parameters.Add("@nguoigui", System.Data.SqlDbType.Image).Value = NguoiGui.ToArray();
            command.Parameters.Add("@hieuxe", System.Data.SqlDbType.Image).Value = HieuXe.ToArray();
            command.Parameters.Add("@anhXe", System.Data.SqlDbType.Image).Value = AnhXe.ToArray();
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = ThoiGianVao;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public DataTable getVehicle(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getTypeVehicle()
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT LoaiXe FROM Xe");
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteVehicle(string ma)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Xe WHERE MaTheXe=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();

            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();

            return count;
        }

        public string totalVehicle()
        {
            return execCount("SELECT COUNT(*) FROM Xe");
        }

        public string totalMotorcycle()
        {
            return execCount("SELECT COUNT(*) FROM Xe WHERE LoaiXe = 'Xe May' ");
        }
        public string totalCar()
        {
            return execCount("SELECT COUNT(*) FROM Xe WHERE LoaiXe = 'Xe Hoi' ");
        }
        public string totalBicycle()
        {
            return execCount("SELECT COUNT(*) FROM Xe WHERE LoaiXe = 'Xe Dap' ");
        }

        //SqlCommand command = new SqlCommand("update Table_Vehicle SET Type_of_vehicle = @type ,
        // Picture = @pic,In_time= @inTime,Out_time= @outTime,Payment =@payment WHERE License_plate = @id", mydb.getConnection);
        public bool updateVehicle(string MaTheXe, string LoaiXe, MemoryStream BienSo, MemoryStream NguoiGui, MemoryStream HieuXe,
                                    MemoryStream AnhXe, DateTime ThoiGianVao, int slot)
        {

            SqlCommand command = new SqlCommand("UPDATE Xe SET  LoaiXe=@loai, BienSo= @bienso,NguoiGui= @nguoigui, HieuXe= @hieuxe,AnhXe= @anhxe,ThoiGianVao=@time,Slot=@slot" +
                "WHERE MaTheXe=@ma", mydb.getConnection);

            command.Parameters.Add("@ma", System.Data.SqlDbType.VarChar).Value = MaTheXe;
            command.Parameters.Add("@loai", System.Data.SqlDbType.VarChar).Value = LoaiXe;
            command.Parameters.Add("@bienso", System.Data.SqlDbType.Image).Value = BienSo.ToArray();
            command.Parameters.Add("@nguoigui", System.Data.SqlDbType.Image).Value = NguoiGui.ToArray();
            command.Parameters.Add("@hieuxe", System.Data.SqlDbType.Image).Value = HieuXe.ToArray();
            command.Parameters.Add("anhXe", System.Data.SqlDbType.Image).Value = AnhXe.ToArray();

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
