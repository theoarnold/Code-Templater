using System.Text;
using System.Text.RegularExpressions;

namespace WorkApp
{
    internal class RepSelections
    {
        private const string RepListValues = @"\[rep[^]]*\]";

        internal string Replace(string template, string[] values)
        {
            StringBuilder sb = new StringBuilder(template);

            if (Regex.IsMatch(template, RepListValues))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string replacementTag = $"[rep{i + 1}]";
                    string lowerCaseTag = $"[rep{i + 1}L]";
                    string upperCaseTag = $"[rep{i + 1}U]";
                    string firstLowerTag = $"[rep{i + 1}FL]";
                    string firstUpperTag = $"[rep{i + 1}FU]";

                    string valueTrim = values[i].TrimStart().Replace("*(", "").Replace(")", "");

                    sb.Replace(replacementTag, valueTrim)
                       .Replace(lowerCaseTag, valueTrim.ToLower())
                       .Replace(upperCaseTag, valueTrim.ToUpper())
                       .Replace(firstLowerTag, valueTrim.Substring(0, 1).ToLower() + valueTrim.Substring(1))
                       .Replace(firstUpperTag, valueTrim.Substring(0, 1).ToUpper() + valueTrim.Substring(1));
                }
            }

            string replacedValue = sb.ToString();

            return replacedValue;
        }
    }
}
