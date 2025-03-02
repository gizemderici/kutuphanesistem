using System;
using System.Data;
using kutup;
using Microsoft.Data.SqlClient;

namespace kutup
{
    public class OduncIslemleri : VeritabaniIslemleri
    {
        public void OduncVer(string oduncAlan, DateTime oduncTarih, int kitapId)
        {
            try
            {
                BaglantiAc();
                SqlCommand komut = new SqlCommand("UPDATE TableKitaplar SET OduncAlan = @P1, OduncAlmaTarih = @P2, Durum = @P3 WHERE ID = @P4", baglanti);
                komut.Parameters.AddWithValue("@P1", oduncAlan);
                komut.Parameters.AddWithValue("@P2", oduncTarih);
                komut.Parameters.AddWithValue("@P3", "False");
                komut.Parameters.AddWithValue("@P4", kitapId);
                komut.ExecuteNonQuery();
            }
            finally
            {
                BaglantiKapat();
            }
        }

        internal void KitabiIadeEt(int kitapId)
        {
            try
            {
                BaglantiAc(); 
                SqlCommand komut = new SqlCommand(
                    "UPDATE TableKitaplar SET OduncAlan = NULL, OduncAlmaTarih = NULL, Durum = @durum WHERE ID = @kitapId",
                    baglanti
                );

                
                komut.Parameters.AddWithValue("@durum", "True");
                komut.Parameters.AddWithValue("@kitapId", kitapId);

                komut.ExecuteNonQuery(); 
            }
            finally
            {
                BaglantiKapat(); 
            }
        }

    }
}
