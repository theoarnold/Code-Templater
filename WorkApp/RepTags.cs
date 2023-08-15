using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp
{
    internal class RepTags
    {
        public string Replace(string template, string? value = null)
        {
            StringBuilder sb = new StringBuilder(template);

            if (value != null)
            {
                sb.Replace("[rep]", value)
                  .Replace("[repL]", value.ToLower())
                  .Replace("[repU]", value.ToUpper())
                  .Replace("[repFL]", value.Substring(0, 1).ToLower() + value.Substring(1))
                  .Replace("[repFU]", value.Substring(0, 1).ToUpper() + value.Substring(1));
            }

           string replacedValue = sb.ToString();

            return replacedValue;
        }
    }
}
