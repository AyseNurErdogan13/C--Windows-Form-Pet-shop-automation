using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace PetShopOtomasyonu
{
    public partial class menu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public menu()
        {
            InitializeComponent();
        }
        frm_market market;
        frmHayvanlar hayvanlar;
        frmMusteriler musteriler;
        frmElemanlar elemanlar;
        frmNotlar notlar;

        private void btnMarket_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (market == null)
            {
                market = new frm_market();
                market.MdiParent = this;
                market.Show();
            }
        }

        private void btnHayvanlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (hayvanlar == null)
            {
                hayvanlar = new frmHayvanlar();
                hayvanlar.MdiParent = this;
                hayvanlar.Show();
            }
        }

        private void btnMusteriler_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (musteriler == null)
            {
                musteriler = new frmMusteriler();
              musteriler.MdiParent = this;
                musteriler.Show();
            }
        }

        private void btnCalisanlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (elemanlar == null)
            {
                elemanlar = new frmElemanlar ();
                elemanlar.MdiParent = this;
                elemanlar.Show();
            }
        }

        private void menu_Load(object sender, EventArgs e)
        {
            frmResim resim = new frmResim();
            resim.MdiParent = this;
            resim.Show();
        }

      

        private void btnNotlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNotlar hsm = new frmNotlar();
            hsm.MdiParent = this;
            hsm.Show();
        }
    }
}