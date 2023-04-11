using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
namespace PetShopOtomasyonu
{
    public partial class AdminEkranı : DevExpress.XtraEditors.XtraForm
    {
        public AdminEkranı()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select*from TBL_ADMIN where KullaniciAd=@p1 and Parola=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtadı.Text);
            komut.Parameters.AddWithValue("@p2", txtparola.Text);
            SqlDataReader dr =komut.ExecuteReader();
            if (dr.Read())
            {
                menu mn = new menu();
                mn.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Parola Girdiniz..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}