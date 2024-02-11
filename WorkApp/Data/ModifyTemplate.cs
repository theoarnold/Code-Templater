using System.Text;
using System.Text.RegularExpressions;

namespace WorkApp.Data
{
    internal class ModifyTemplate
    {
        private const string StartTag = "<repList>";
        private const string EndTag = "</repList>";
        private const string RepListValues = @"\[rep[^]]*\]";

        internal string RepList(string template, string[] values)
        {
            int startIndex = template.IndexOf(StartTag);
            int endIndex = template.IndexOf(EndTag);

            if (startIndex != -1 && endIndex != -1)
            {
                string substring = template.Substring(startIndex + StartTag.Length, endIndex - startIndex - StartTag.Length);
                StringBuilder modifiedSubstring = new StringBuilder();

                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("*(") && !values[i].Contains(")"))
                    {
                        string replacedValue = RepTags.Replace(substring, values[i].TrimStart());
                        modifiedSubstring.AppendLine(replacedValue);
                    }
                }

                template = template.Remove(startIndex, endIndex + EndTag.Length - startIndex)
                                   .Insert(startIndex, modifiedSubstring.ToString());
            }

            return template;
        }

        internal string RepSelections(string template, string[] values)
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

        internal string RemainingReplacements(string[] values, string modifiedTemplate)
        {
            StringBuilder result = new StringBuilder();

            if (Regex.IsMatch(modifiedTemplate, RepListValues))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("*(") && !values[i].Contains(")"))
                    {
                        string replacedValue = RepTags.Replace(modifiedTemplate, values[i].TrimStart());
                        result.AppendLine(replacedValue);
                    }
                }
            }
            else
            {
                string replacedValue = RepTags.Replace(modifiedTemplate);
                result.AppendLine(replacedValue);
            }

            return result.ToString();
        }
    }
}