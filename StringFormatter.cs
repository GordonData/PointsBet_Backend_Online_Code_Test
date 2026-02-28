using System.Text;

namespace PointsBet_Backend_Online_Code_Test
{
    public class StringFormatter
    {
        // 1. Important to add XML doc comments as below for IntelliSense, for maintenance, and for DocFX to generate documentation.
        // 2. https://en.wikipedia.org/wiki/Comma-separated_values
        //    If a technical standard already exists, it is important to abide by it; otherwise, interoperability will be lost.
        //    Therefore, the parameter "quote" should be avoided — it must always be double quotes per RFC 4180.
        
        /// <summary>
        /// Formats an array of strings into a comma-separated value (CSV) string.
        /// </summary>
        /// <param name="items">The array of strings to format.</param>
        /// <returns>The comma-separated value; null if the array is null, string.Empty if the array is empty.</returns>
        public static string ToCommaSeparatedList(string[] items) // ToCommaSepatatedList had a typo
        {
            // Always important to check inputs for abnormal values
            if (items == null)
                return null;
            if (items.Length == 0)
                return string.Empty;

            const char comma = ',', quote = '"';
            StringBuilder sb = new StringBuilder(); // No need to initialise StringBuilder with a value, especially when it results in redundant code. 
                                                    // sb is better than qry for a StringBuilder variable, unless it is used to build a query string. 
            for (int i = 0; i < items.Length; i++)  // In C#, loop normally starts from 0
            {
                if (i > 0)
                    sb.Append(comma);

                // RFC 4180: Any field may be enclosed in double quotes 
                sb.Append(quote);
                // RFC 4180: If a field is enclosed in double quotes, then a double quote embedded in the field must be represented by a sequence of two double quotes
                sb.Append(items[i].Replace(quote.ToString(), string.Concat(quote, quote)));
                sb.Append(quote);
            }

            return sb.ToString();
        }
    }
}
