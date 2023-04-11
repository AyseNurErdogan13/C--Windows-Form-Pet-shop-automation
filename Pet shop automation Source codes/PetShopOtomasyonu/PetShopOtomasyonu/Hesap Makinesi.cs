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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void frmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_NOTLAR (ADI,SOYADI,TARİHİ,NOTLAR) values (@p1,@p2,@p3,@p4)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAdı.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadı.Text);
            komut.Parameters.AddWithValue("@p3", txtTarihi.Text);
            komut.Parameters.AddWithValue("@p4", richTextBoxNot.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_NOTLAR where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("UPDATE TBL_NOTLAR set ADI=@p1,SOYADI=@p2,TARİHİ=@p3,NOTLAR=@p4 where ID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdı.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyadı.Text);
            komut.Parameters.AddWithValue("@p3", txtTarihi.Text);
            komut.Parameters.AddWithValue("@p4", richTextBoxNot.Text);
            komut.Parameters.AddWithValue("@p5", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAdı.Text = dr["ADI"].ToString();
            txtSoyadı.Text = dr["SOYADI"].ToString();
            txtTarihi.Text = dr["TARİHİ"].ToString();
            richTextBoxNot.Text = dr["NOTLAR"].ToString();
        }
    }
}
