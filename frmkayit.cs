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
using System.Security.Cryptography;

namespace Personel_Kayıt
{
    public partial class frmkayit : Form
    {
        public frmkayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DU4I803;Initial Catalog=PersonelVeriTabni;Integrated Security=True");

        private void btnregister_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("İnsert İnto tbl_yonetici (KullaniciAd,Sifre) values (@x1,@x2) ", baglanti);
            komut.Parameters.AddWithValue("@x1", txtusername.Text);
            komut.Parameters.AddWithValue("@x2", txtpsw.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Tamamlanmıştır");
            frmgiris fr = new frmgiris();
            fr.Show();
            this.Hide();
        }
    }
}
