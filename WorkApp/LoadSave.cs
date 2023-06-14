
namespace WorkApp
{
    internal static class LoadSave
    {
        public static void SaveContent(string content)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, content);
                MessageBox.Show("File saved successfully!");
            }
        }

        public static void LoadContent(TextBox textBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string content = File.ReadAllText(filePath);
                textBox.Text = content;
                MessageBox.Show("File loaded successfully!");
            }
        }
    }
}
