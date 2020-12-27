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
using System.Data.Sql;

namespace Personel_Kayıt
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DU4I803;Initial Catalog=PersonelVeriTabni;Integrated Security=True");

        private void frm_istatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltopper.Text = dr1[0].ToString();
            }
            baglanti.Close();

            // Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From tbl_Personel Where Durum = 1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliper.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From tbl_Personel  Where Durum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarper.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(Distinct(Şehir)) From tbl_Personel  ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read()) 
            {
                lblsehirsay.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // Toplam Maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(Maaş) From tbl_Personel  ", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltopmaaş.Text = dr5[0].ToString();
            }
            baglanti.Close();

            // Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(Maaş) From tbl_Personel  ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaaş.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
