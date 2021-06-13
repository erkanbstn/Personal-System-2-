using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeSoru1._01
{
    public partial class Form3 : Form
    {
        DbConnection db = new DbConnection();
        public int personelId;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            db.connection.Open();
            db.command = new SqlCommand("sevkinfo",db.connection);
            db.command.CommandType = CommandType.StoredProcedure;
            db.command.Parameters.AddWithValue("@personelID", personelId);
            //db.command.CommandText = "sevkdetay";
            //db.command.Connection = db.connection;
            //SqlParameter param = new SqlParameter("@deger", personelId);
            //param.Direction = ParameterDirection.Input;
            //param.DbType = DbType.Int32;
            //db.command.Parameters.Add(param);
            db.command.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(db.command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            db.connection.Close();


        }
    }
}
