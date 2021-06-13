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
    public partial class Form5 : Form
    {
       
        public Form5()
        {
            InitializeComponent();
        }

        public string no;
  

        DbConnection db = new DbConnection();
        private void Form5_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT dbo.Musteriler.MusteriID as 'MüşteriID', dbo.Musteriler.MusteriAdi as 'Müşteri' , dbo.Musteriler.Telefon, dbo.Personeller.Adi as 'Personel', dbo.Urunler.UrunAdi, dbo.Urunler.BirimFiyati,[Satis Detaylari].Miktar,Urunler.BirimFiyati*[Satis Detaylari].Miktar as 'Toplam Fiyat', dbo.Satislar.SatisTarihi, dbo.Satislar.OdemeTarihi FROM dbo.Musteriler INNER JOIN  dbo.Satislar ON dbo.Musteriler.MusteriID = dbo.Satislar.MusteriID INNER JOIN dbo.Personeller ON dbo.Satislar.PersonelID = dbo.Personeller.PersonelID INNER JOIN dbo.[Satis Detaylari] ON dbo.Satislar.SatisID = dbo.[Satis Detaylari].SatisID INNER JOIN dbo.Urunler ON dbo.[Satis Detaylari].UrunID = dbo.Urunler.UrunID where Musteriler.Extension="+no,db.connection);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
           
        }
    }
}
