using Microsoft.Data.SqlClient;
using System.Data;

namespace kutup
{
    public abstract class VeritabaniIslemleri : IVeritabaniIslemleri
    {
        protected SqlConnection baglanti = new SqlConnection(@"Data Source=GIZEM\SQLEXPRESS;Initial Catalog=DbKutuphane;Integrated Security=True;Trust Server Certificate=True");

        public void BaglantiAc()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
        }

        public void BaglantiKapat()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
        }
    }

   
}
