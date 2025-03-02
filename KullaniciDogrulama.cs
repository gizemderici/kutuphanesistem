using System.Data;
using kutup;
using Microsoft.Data.SqlClient;

namespace kutup
{
    public class KullaniciDogrulama : VeritabaniIslemleri
    {
        public string KullaniciSifresiGetir(string kullaniciAdi)
        {
            string sifre = "";
            try
            {
                BaglantiAc();
                SqlCommand komut = new SqlCommand("SELECT Sifre FROM TableKullanici WHERE KullaniciAdi = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", kullaniciAdi);
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    sifre = okuyucu[0].ToString();
                }
            }
            finally
            {
                BaglantiKapat();
            }
            return sifre;
        }
    }
}
