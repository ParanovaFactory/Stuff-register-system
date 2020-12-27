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

namespace Personel_Kayıt
{
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DU4I803;Initial Catalog=PersonelVeriTabni;Integrated Security=True");

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            // Şehirler
            baglanti.Open();
            SqlCommand g1 = new SqlCommand("Select Şehir,Count(*) From tbl_Personel Group By Şehir", baglanti);
            SqlDataReader dr1 = g1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();


            // Meslek-Maaş
            baglanti.Open();
            SqlCommand g2 = new SqlCommand("Select Meslek,Avg(Maaş) From tbl_Personel Group By Meslek", baglanti);
            SqlDataReader dr2 = g2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
