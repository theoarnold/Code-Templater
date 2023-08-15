using System.Text;

namespace WorkApp
{
    internal class RepList
    {
        private const string StartTag = "<repList>";
        private const string EndTag = "</repList>";
        public string Replace(string template, string[] values)
        {

            int startIndex = template.IndexOf(StartTag);
            int endIndex = template.IndexOf(EndTag);

            RepTags repTags = new RepTags();

            if (startIndex != -1 && endIndex != -1)
            {
                string substring = template.Substring(startIndex + StartTag.Length, endIndex - startIndex - StartTag.Length);
                StringBuilder modifiedSubstring = new StringBuilder();

                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("*(") && !values[i].Contains(")"))
                    {
                        string replacedValue = repTags.Replace(substring, values[i].TrimStart());
                        modifiedSubstring.AppendLine(replacedValue);
                    }
                }

                template = template.Remove(startIndex, endIndex + EndTag.Length - startIndex)
                                   .Insert(startIndex, modifiedSubstring.ToString());
            }

            return template;
        }
    }
}