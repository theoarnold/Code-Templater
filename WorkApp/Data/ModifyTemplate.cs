using System.Text;
using System.Text.RegularExpressions;

namespace WorkApp.Data
{
    public class TemplateProcessor
    {
        private const string StartTag = "<repList>";
        private const string EndTag = "</repList>";
        private const string RepListValues = @"\[rep[^]]*\]";
        private readonly string[] values;
        private readonly string template;
        private readonly StringBuilder sb;

        public TemplateProcessor(string[] values, string template)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));
            this.template = template ?? throw new ArgumentNullException(nameof(template));

            // Updated to create one stringbuilder, less readable but clearing the same stringbuilder and reusing is slightly faster.
            sb = new StringBuilder(template.Length * 2); // Estimate initial capacity
        }

        public string ProcessTemplate()
        {
            string processedTemplate = template;
            processedTemplate = ProcessRepList(processedTemplate);
            processedTemplate = ProcessRepSelections(processedTemplate);
            processedTemplate = ProcessRemainingReplacements(processedTemplate);
            return processedTemplate;
        }

        private string ProcessRepList(string input)
        {
            int startIndex = input.IndexOf(StartTag);
            int endIndex = input.IndexOf(EndTag);

            string substring = input.Substring(startIndex + StartTag.Length,
                                            endIndex - startIndex - StartTag.Length);

            sb.Clear();

            foreach (string value in values.Where(v => !v.Contains("*(") && !v.Contains(")")))
            {
                string replacedValue = RepTags.Replace(substring, value.TrimStart());
                sb.AppendLine(replacedValue);
            }

            return input.Remove(startIndex, endIndex + EndTag.Length - startIndex)
                       .Insert(startIndex, sb.ToString());
        }

        private string ProcessRepSelections(string input)
        {
            if (!Regex.IsMatch(input, RepListValues))
                return input;

            sb.Clear().Append(input);

            int index = 1;

            foreach (string value in values)
            {
                string cleanValue = value.TrimStart().Replace("*(", "").Replace(")", "");

                if (!string.IsNullOrEmpty(cleanValue))
                {
                   sb.Replace($"[rep{index}]", cleanValue)
                     .Replace($"[rep{index}L]", cleanValue.ToLower())
                     .Replace($"[rep{index}U]", cleanValue.ToUpper())
                     .Replace($"[rep{index}FL]", char.ToLower(cleanValue[0]) + cleanValue[1..])
                     .Replace($"[rep{index}FU]", char.ToUpper(cleanValue[0]) + cleanValue[1..]);
                }

                index++;
            }

            return sb.ToString();
        }

        private string ProcessRemainingReplacements(string input)
        {
            if (!Regex.IsMatch(input, RepListValues))
            {
                return RepTags.Replace(input);
            }

            sb.Clear();

            foreach (string value in values.Where(v => !v.Contains("*(") && !v.Contains(")")))
            {
                string replacedValue = RepTags.Replace(input, value.TrimStart());
                sb.AppendLine(replacedValue);
            }
            return sb.ToString();
        }
    }
}