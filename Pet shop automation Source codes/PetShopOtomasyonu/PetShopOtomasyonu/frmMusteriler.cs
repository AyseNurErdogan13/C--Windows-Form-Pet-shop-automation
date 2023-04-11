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
namespace PetShopOtomasyonu
{
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERİLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Insert into TBL_MUSTERİLER (ADI,SOYAD,TELEFON,ADRES,HAYVAN,MARKET) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
           
            komut.Parameters.AddWithValue("@p1", txtAdı.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", txtAdresi.Text);
            komut.Parameters.AddWithValue("@p5", txtHayvan.Text);
            komut.Parameters.AddWithValue("@p6", txtUrun.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Müşteri Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_MUSTERİLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERİLER set ADI=@p1,SOYAD=@p2,TELEFON=@p3,ADRES=@p4,HAYVAN=@p5,MARKET=@p6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtAdı.Text);
            komut.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",txtTelefon.Text);
            komut.Parameters.AddWithValue("@p4",txtAdresi.Text);
            komut.Parameters.AddWithValue("@p5", txtHayvan.Text);
            komut.Parameters.AddWithValue("@p6", txtUrun.Text);
            komut.Parameters.AddWithValue("@p7", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAdı.Text = dr["ADI"].ToString();
            txtSoyad.Text = dr["SOYAD"].ToString();
            txtTelefon.Text = dr["TELEFON"].ToString();
            txtAdresi.Text = dr["ADRES"].ToString();
            txtHayvan.Text = dr["HAYVAN"].ToString();
            txtUrun.Text = dr["MARKET"].ToString();
        }
    }
}
