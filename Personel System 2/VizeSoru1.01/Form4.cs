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

namespace VizeSoru1._01
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        DbConnection db = new DbConnection();
        private void button2_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            SqlCommand d = new SqlCommand("Select MusteriAdi,Extension from Musteriler where MusteriAdi=@p1 and Extension=@p2",db.connection);
            d.Parameters.AddWithValue("@p1",textBox1.Text);
            d.Parameters.AddWithValue("@p2",textBox2.Text);
            SqlDataReader dr = d.ExecuteReader();
            if (dr.Read())
            {
                Form5 f = new Form5();
                f.no = dr[1].ToString();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            db.connection.Close();
        }
    }
}
