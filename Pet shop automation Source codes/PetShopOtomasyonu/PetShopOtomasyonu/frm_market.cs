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
    public partial class frm_market : Form
    {
        public frm_market ()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MARKET",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
       

        private void simpleButtonkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_MARKET(URUNADI,URUNADEDİ,URUNFİYATI) values (@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textadı.Text);
            komut.Parameters.AddWithValue("@p2",textadedi.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textfiyatı.Text));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Ürün Markete Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void frm_market_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_MARKET where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", textıd.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MARKET set URUNADI=@p1,URUNADEDİ=@p2,URUNFİYATI=@p3 where ID=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textadı.Text);
            komut.Parameters.AddWithValue("@p2", textadedi.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textfiyatı.Text));
            komut.Parameters.AddWithValue("@p4", textıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textıd.Text = dr["ID"].ToString();
            textadı.Text = dr["URUNADI"].ToString();
            textadedi.Text = dr["URUNADEDİ"].ToString();
            textfiyatı.Text = dr["URUNFİYATI"].ToString();
        }

        
    }
}
