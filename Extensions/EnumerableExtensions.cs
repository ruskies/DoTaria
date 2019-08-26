using System.Collections.Generic;
using System.Text;

namespace DoTaria.Extensions
{
    public static class EnumerableExtensions
    {
        public static string GenerateSlashedString(this List<float> values) => GenerateSlashedString(values.ToArray());

        public static string GenerateSlashedString(this float[] values)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                sb.Append(values[i]);

                if (i + 1 < values.Length)
                    sb.Append('/');
            }

            return sb.ToString();
        }
    }
}