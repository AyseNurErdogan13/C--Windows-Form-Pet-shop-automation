using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace PetShopOtomasyonu
{
    class sqlbaglantisi
    {
        public string baglantıAdres = System.IO.File.ReadAllText(@"C:\Test.txt");
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(baglantıAdres);
            baglan.Open();
            return baglan;
        }
    }
}
