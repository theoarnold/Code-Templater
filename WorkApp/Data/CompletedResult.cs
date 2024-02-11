namespace WorkApp.Data
{
    internal class CompletedResult
    {
        internal void Show(string finished)
        {
            Form2 form2 = new Form2();
            form2.textBox1_DisplayResult(finished);
            form2.ShowDialog();
        }
    }
}
