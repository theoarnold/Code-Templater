using System.Text;

namespace WorkApp.Data
{
    internal static class RepTags
    {
        internal static string Replace(string template, string? value = null)
        {
            StringBuilder sb = new StringBuilder(template);

            if (!string.IsNullOrEmpty(value))
            {
                sb.Replace("[rep]", value)
                  .Replace("[repL]", value.ToLower())
                  .Replace("[repU]", value.ToUpper())
                  .Replace("[repFL]", char.ToLower(value[0]) + value[1..])
                  .Replace("[repFU]", char.ToUpper(value[0]) + value[1..]);
            }

            string replacedValue = sb.ToString();

            return replacedValue;
        }
    }
}