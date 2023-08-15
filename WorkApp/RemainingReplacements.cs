using System.Text;
using System.Text.RegularExpressions;

namespace WorkApp
{
    internal class RemainingReplacements
    {
        private const string RepListValues = @"\[rep[^]]*\]";

        internal string ReadValues(string[] values, string modifiedTemplate)
        {
            StringBuilder result = new StringBuilder();
            RepTags repTags = new RepTags();

            if (Regex.IsMatch(modifiedTemplate, RepListValues))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("*(") && !values[i].Contains(")"))
                    {
                        string replacedValue = repTags.Replace(modifiedTemplate, values[i].TrimStart());
                        result.AppendLine(replacedValue);
                    }
                }
            }
            else
            {
                string replacedValue = repTags.Replace(modifiedTemplate);
                result.AppendLine(replacedValue);
            }

            return result.ToString();
        }
    }
}
