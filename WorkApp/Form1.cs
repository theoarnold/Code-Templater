using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkApp
{
    public partial class Form1 : Form
    {
        private int numericUpDownValue = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string template = textBox2.Text;
            string[] res = text.Split(',');
            string s = string.Join(" ", res);

            Run.StartAutomate(res, template);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep]";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[repL]";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[repU]";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownValue = (int)numericUpDown1.Value;
            button5.Text = "[rep" + numericUpDownValue.ToString() + "]";
            button6.Text = "[rep" + numericUpDownValue.ToString() + "L]";
            button7.Text = "[rep" + numericUpDownValue.ToString() + "U]";
            button11.Text = "[rep" + numericUpDownValue.ToString() + "FL]";
            button12.Text = "[rep" + numericUpDownValue.ToString() + "FU]";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep" + numericUpDownValue + "]";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep" + numericUpDownValue + "L]";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep" + numericUpDownValue + "U]";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSave.LoadContent(textBox2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadSave.SaveContent(textBox2.Text);
        }

        private void btnLoad2_Click(object sender, EventArgs e)
        {
            LoadSave.LoadContent(textBox2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[repFL]";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[repFU]";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep" + numericUpDownValue + "FL]";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "[rep" + numericUpDownValue + "FU]";
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox2.SelectedText = "<repList>";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "</repList>";
        }
    }
}