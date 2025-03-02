using System.Windows.Forms;

namespace kutup
{
    public class TemizlemeIslemleri
    {
        public void FormuTemizle(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }
    }
}
