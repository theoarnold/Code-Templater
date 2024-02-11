using System.Windows.Forms;
using System.Windows;

namespace WorkApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void textBox1_DisplayResult(string finished)
        {
            textBox1.Text = finished;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textBoxContents = textBox1.Text;
            Clipboard.SetText(textBoxContents);
        }
    }
}
