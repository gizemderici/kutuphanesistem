using System.Data;
using kutup;
using Microsoft.Data.SqlClient;

namespace kutup
{
    public class KitapIslemleri : VeritabaniIslemleri
    {
        public void KitapEkle(string kitapAdi, string yazarAdi, string kitapTurKod)
        {
            try
            {
                BaglantiAc();
                SqlCommand komut = new SqlCommand("INSERT INTO TableKitaplar (KitapAdi, YazarAdi, Durum, KitapTurKod) VALUES (@P1, @P2, @P3, @P4)", baglanti);
                komut.Parameters.AddWithValue("@P1", kitapAdi);
                komut.Parameters.AddWithValue("@P2", yazarAdi);
                komut.Parameters.AddWithValue("@P3", "True");
                komut.Parameters.AddWithValue("@P4", kitapTurKod);
                komut.ExecuteNonQuery();
            }
            finally
            {
                BaglantiKapat();
            }
        }

        public DataTable KitaplariGetir()
        {
            DataTable tablo = new DataTable();
            try
            {
                BaglantiAc();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TableKitaplar", baglanti);
                da.Fill(tablo);
            }
            finally
            {
                BaglantiKapat();
            }
            return tablo;
        }

        internal DataTable KitapAra(string kitapAdi, string yazarAdi, string kitapTurKod, string oduncAlan)
        {
            DataTable tablo = new DataTable();
            try
            {
                BaglantiAc(); 
                string query = "SELECT * FROM TableKitaplar WHERE 1=1";

                
                if (!string.IsNullOrWhiteSpace(kitapAdi))
                    query += " AND KitapAdi LIKE @kitapAdi";

                if (!string.IsNullOrWhiteSpace(yazarAdi))
                    query += " AND YazarAdi LIKE @yazarAdi";

                if (!string.IsNullOrWhiteSpace(kitapTurKod))
                    query += " AND KitapTurKod LIKE @kitapTurKod";

                if (!string.IsNullOrWhiteSpace(oduncAlan))
                    query += " AND OduncAlan LIKE @oduncAlan";

                SqlCommand komut = new SqlCommand(query, baglanti);

                
                if (!string.IsNullOrWhiteSpace(kitapAdi))
                    komut.Parameters.AddWithValue("@kitapAdi", kitapAdi + "%");

                if (!string.IsNullOrWhiteSpace(yazarAdi))
                    komut.Parameters.AddWithValue("@yazarAdi", yazarAdi + "%"); 

                if (!string.IsNullOrWhiteSpace(kitapTurKod))
                    komut.Parameters.AddWithValue("@kitapTurKod", kitapTurKod + "%");

                if (!string.IsNullOrWhiteSpace(oduncAlan))
                    komut.Parameters.AddWithValue("@oduncAlan", oduncAlan + "%"); 

                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(tablo); 
            }
            finally
            {
                BaglantiKapat();
            }
            return tablo; 
        }


        internal void KitapGuncelle(int kitapId, string kitapAdi, string yazarAdi, string kitapTurKod)
        {
            try
            {
                BaglantiAc(); 
                SqlCommand komut = new SqlCommand(
                    "UPDATE TableKitaplar SET KitapAdi = @kitapAdi, YazarAdi = @yazarAdi, KitapTurKod = @kitapTurKod WHERE ID = @kitapId",
                    baglanti
                );

                
                komut.Parameters.AddWithValue("@kitapAdi", kitapAdi);
                komut.Parameters.AddWithValue("@yazarAdi", yazarAdi);
                komut.Parameters.AddWithValue("@kitapTurKod", kitapTurKod);
                komut.Parameters.AddWithValue("@kitapId", kitapId);

                komut.ExecuteNonQuery();
            }
            finally
            {
                BaglantiKapat();
            }
        }


        internal void KitapSil(int kitapId)
        {
            try
            {
                BaglantiAc(); 
                SqlCommand komut = new SqlCommand("DELETE FROM TableKitaplar WHERE ID = @kitapId", baglanti);

                
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
