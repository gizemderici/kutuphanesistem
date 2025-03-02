using kutup;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kutup
{
    public partial class Form1 : Form
    {
        KullaniciDogrulama kullaniciDogrulama = new KullaniciDogrulama();

        public Form1(object filename)
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string girilenSifre = textBox2.Text;

            try
            {
                string dogruSifre = kullaniciDogrulama.KullaniciSifresiGetir(kullaniciAdi);

                if (dogruSifre == girilenSifre)
                {
                    label3.Text = "Þifre doðru!";
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Kullanýcý adý veya þifre yanlýþ.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Baðlantý hatasý: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
