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
    public partial class frmElemanlar : Form
    {
        public frmElemanlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void frmElemanlar_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_CALİSANLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_CALİSANLAR (ADI,SOYADI,GOREVİ,TELEFON) values (@p1,@p2,@p3,@p4)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAdı.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadı.Text);
            komut.Parameters.AddWithValue("@p3", txtGorevi.Text);
            komut.Parameters.AddWithValue("@p4", txtTelefon.Text);
            
           
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Çalışan Eleman Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_CALİSANLAR where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Çalışan Eleman Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_CALİSANLAR set ADI=@p1,SOYADI=@p2,GOREVİ=@p3,TELEFON=@p4 where ID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdı.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadı.Text);
            komut.Parameters.AddWithValue("@p3", txtGorevi.Text);
            komut.Parameters.AddWithValue("@p4", txtTelefon.Text); 
            komut.Parameters.AddWithValue("@p5", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Çalışan Eleman Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAdı.Text = dr["ADI"].ToString();
            txtSoyadı.Text = dr["SOYADI"].ToString();
            txtGorevi.Text = dr["GOREVİ"].ToString();
            txtTelefon.Text = dr["TELEFON"].ToString();
          
        }
    }
}
