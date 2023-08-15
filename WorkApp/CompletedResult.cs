using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp
{
    internal class CompletedResult
    {
        public void Show(string finished)
        {
            Form2 form2 = new Form2();
            form2.textBox1_DisplayResult(finished);
            form2.ShowDialog();
        }
    }
}
