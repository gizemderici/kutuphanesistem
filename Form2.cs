using System;
using System.Windows.Forms;
using System.Data;

namespace kutup
{
    public partial class Form2 : Form
    {
        KitapIslemleri kitapIslemleri = new KitapIslemleri();
        OduncIslemleri oduncIslemleri = new OduncIslemleri();
        TemizlemeIslemleri temizlemeIslemleri = new TemizlemeIslemleri();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void VerileriGoster()
        {
            try
            {
                DataTable kitaplar = kitapIslemleri.KitaplariGetir();
                if (kitaplar.Rows.Count > 0)
                {
                    dataGridView1.DataSource = kitaplar;
                }
                else
                {
                    MessageBox.Show("Hiç kitap bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                kitapIslemleri.KitapEkle(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim());
                MessageBox.Show("Kitap başarıyla eklendi.");
                VerileriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap eklenirken hata oluştu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(label1.Text, out int kitapId))
                {
                    MessageBox.Show("Geçerli bir kitap seçin.");
                    return;
                }

                
                kitapIslemleri.KitapGuncelle(kitapId, textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim());
                MessageBox.Show("Kitap başarıyla güncellendi.");
                VerileriGoster(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap güncellenirken hata oluştu: " + ex.Message);
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(label1.Text, out _))
                {
                    MessageBox.Show("Geçerli bir kitap seçin.");
                    return;
                }
                int gecikmeBedeli = 0;
                DateTime oduncTarih = dateTimePicker1.Value;
                DateTime bugun = DateTime.Now;
                int gunFarki = (int)(bugun - oduncTarih).TotalDays;
                if (gunFarki > 30)
                {
                    CezaHesaplama cezaHesaplama2 = new CezaHesaplama();
                    gecikmeBedeli = cezaHesaplama2.GecikmeCezasiHesapla(oduncTarih, gunFarki);
                }
                else if (gunFarki > 10)
                {
                    CezaHesaplamaBase cezaHesaplama = new CezaHesaplamaBase();
                    
                   gecikmeBedeli=cezaHesaplama.GecikmeCezasiHesapla(oduncTarih, gunFarki);
                    

                }
             

               

                label9.Text = gecikmeBedeli > 0 ? gecikmeBedeli.ToString() : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ceza hesaplanırken hata oluştu: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(label1.Text, out int kitapId)) 
                {
                    MessageBox.Show("Geçerli bir kitap seçin.");
                    return;
                }

                
                oduncIslemleri.KitabiIadeEt(kitapId);
                MessageBox.Show("Kitap başarıyla iade edildi.");
                VerileriGoster(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap iade edilirken hata oluştu: " + ex.Message);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(label1.Text, out int kitapId))
                {
                    MessageBox.Show("Geçerli bir kitap seçin.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Lütfen ödünç alan kişinin adını girin.");
                    return;
                }

                oduncIslemleri.OduncVer(textBox4.Text.Trim(), dateTimePicker1.Value, kitapId);
                MessageBox.Show("Kitap ödünç verildi.");
                VerileriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap ödünç verilirken hata oluştu: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizlemeIslemleri.FormuTemizle(textBox1, textBox2, textBox3, textBox4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string kitapAdi = textBox1.Text.Trim();
                string yazarAdi = textBox2.Text.Trim();
                string kitapTurKod = textBox3.Text.Trim();
                string oduncAlan = textBox4.Text.Trim();

                DataTable sonuc = kitapIslemleri.KitapAra(kitapAdi, yazarAdi, kitapTurKod, oduncAlan);
                if (sonuc.Rows.Count > 0)
                {
                    dataGridView1.DataSource = sonuc; 
                }
                else
                {
                    MessageBox.Show("Arama sonuçları bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama yapılırken bir hata oluştu: " + ex.Message);
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(label1.Text, out int kitapId)) 
                {
                    MessageBox.Show("Lütfen geçerli bir kitap seçin.");
                    return;
                }

                kitapIslemleri.KitapSil(kitapId); 
                MessageBox.Show("Kitap başarıyla silindi.");
                VerileriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap silinirken bir hata oluştu: " + ex.Message);
            }
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
