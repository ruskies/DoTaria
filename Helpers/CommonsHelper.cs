using System.Text.RegularExpressions;

namespace DoTaria.Helpers
{
    public static class CommonsHelper
    {
        public static string AddSpaceBeforeCapitals(this string str) =>
            string.Join(" ", Regex.Split(str, @"(?<!^)(?=[A-Z])"));
    }
}