using System.Text;
using System.Text.RegularExpressions;

namespace WorkApp
{
    internal static class Run
    {
        public static void StartAutomate(string[] values, string template)
        {
            StringBuilder result = new StringBuilder();

            string modifiedTemplate = BuildRepListValues(template, values);
            string modifiedTemplateStage2 = BuildRepSelections(modifiedTemplate, values);

            string repListValues = @"\[rep[^]]*\]";

            if (Regex.IsMatch(modifiedTemplateStage2, repListValues))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("(") && !values[i].Contains(")"))
                    {
                        string replacedValue = BuildRep(modifiedTemplateStage2, values[i].TrimStart());
                        result.AppendLine(replacedValue);
                    }
                }
            }
            else
            {
                string replacedValue = BuildRep(modifiedTemplateStage2);
                result.AppendLine(replacedValue);
            }

            string finalResult = result.ToString();
            ShowResult(finalResult);
        }

        private static string BuildRepListValues(string template, string[] values)
        {
            string startTag = "<repList>";
            string endTag = "</repList>";

            int startIndex = template.IndexOf(startTag);
            int endIndex = template.IndexOf(endTag);


            if (startIndex != -1 && endIndex != -1)
            {
                string substring = template.Substring(startIndex + startTag.Length, endIndex - startIndex - startTag.Length);
                StringBuilder modifiedSubstring = new StringBuilder();

                for (int i = 0; i < values.Length; i++)
                {
                    if (!values[i].Contains("(") && !values[i].Contains(")"))
                    {
                    string replacedValue = BuildRep(substring, values[i].TrimStart());
                    modifiedSubstring.AppendLine(replacedValue);
                    }
                }

                template = template.Remove(startIndex, endIndex + endTag.Length - startIndex)
                                   .Insert(startIndex, modifiedSubstring.ToString());
            }

            return template;
        }

        private static string BuildRepSelections(string template, string[] values)
        {
            StringBuilder sb = new StringBuilder(template);
            string repListValues = @"\[rep[^]]*\]";

            if (Regex.IsMatch(template, repListValues))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string replacementTag = $"[rep{i + 1}]";
                    string lowerCaseTag = $"[rep{i + 1}L]";
                    string upperCaseTag = $"[rep{i + 1}U]";
                    string firstLowerTag = $"[rep{i + 1}FL]";
                    string firstUpperTag = $"[rep{i + 1}FU]";

                    string valueTrim = values[i].TrimStart();

                    sb.Replace(replacementTag, valueTrim)
                       .Replace(lowerCaseTag, valueTrim.ToLower())
                       .Replace(upperCaseTag, valueTrim.ToUpper())
                       .Replace(firstLowerTag, valueTrim.Substring(0, 1).ToLower() + valueTrim.Substring(1))
                       .Replace(firstUpperTag, valueTrim.Substring(0, 1).ToUpper() + valueTrim.Substring(1));
                }
            }

            string replacedValue = sb.ToString().Replace("(", "").Replace(")", "");

            return replacedValue;
        }

        private static string BuildRep(string template, string? value = null)
        {
            string replacedValue = template;
            StringBuilder sb = new StringBuilder(template);
            if (value != null)
            {
                sb.Replace("[rep]", value)
                  .Replace("[repL]", value.ToLower())
                  .Replace("[repU]", value.ToUpper())
                  .Replace("[repFL]", value.Substring(0, 1).ToLower() + value.Substring(1))
                  .Replace("[repFU]", value.Substring(0, 1).ToUpper() + value.Substring(1));

            }

            replacedValue = sb.ToString();

            return replacedValue;
        }

        private static void ShowResult(string finished)
        {

            Form2 form2 = new Form2();
            form2.textBox1_DisplayResult(finished);
            form2.ShowDialog();
        }
    }
}