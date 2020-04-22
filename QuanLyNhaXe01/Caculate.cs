using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe01
{
    class Caculate
    {
        MyDB mydb = new MyDB();
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
       
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

       /* public DataTable insertMoney(SqlCommand cmd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            
            return table;
        }*/
    }
}
