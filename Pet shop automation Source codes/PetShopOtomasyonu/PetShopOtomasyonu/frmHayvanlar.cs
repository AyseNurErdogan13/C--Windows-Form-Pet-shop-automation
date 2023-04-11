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
    public partial class frmHayvanlar : Form
    {
        public frmHayvanlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_HAYVANLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmHayvanlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_HAYVANLAR(HAYVANTURU,HAYVANCİNSİ,HAYVANYASI,HAYVANMİKTARI,HAYVANFİYATI) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTuru.Text);
            komut.Parameters.AddWithValue("@p2", txtCinsi.Text);
            komut.Parameters.AddWithValue("@p3", txtYası.Text);
            komut.Parameters.AddWithValue("@p4", txtAdedi.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtFiyatı.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Hayvan Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_HAYVANLAR where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtTuru.Text = dr["HAYVANTURU"].ToString();
            txtCinsi.Text = dr["HAYVANCİNSİ"].ToString();
            txtYası.Text = dr["HAYVANYASI"].ToString();
            txtAdedi.Text = dr["HAYVANMİKTARI"].ToString();
            txtFiyatı.Text = dr["HAYVANFİYATI"].ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_HAYVANLAR set HAYVANTURU=@p1,HAYVANCİNSİ=@p2,HAYVANYASI=@p3,HAYVANMİKTARI=@p4,HAYVANFİYATI=@p5 where ID=@p6", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTuru.Text);
            komut.Parameters.AddWithValue("@p2", txtCinsi.Text);
            komut.Parameters.AddWithValue("@p3",txtYası.Text);
            komut.Parameters.AddWithValue("@p4", txtAdedi.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtFiyatı.Text));
            komut.Parameters.AddWithValue("@p6", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Hayvan Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
    }
}
