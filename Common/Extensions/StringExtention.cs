using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class StringExtention
    {
        public static int? ToNullableInt(this string str)
        {
            if (int.TryParse(str, out int res))
                return res;
            return null;
        }

        public static int? InnerExceptionCode(this string str)
        {
            var re = new Regex(@"^(\d+)\.\s?(.+?)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
            var match = re.Match(str);

            return match.Success ? match.Groups[0].Value.ToNullableInt() : null;
        }

        public static string CutInnerExceptionCode(this string str)
        {
            var re = new Regex(@"^(\d+)\.\s?(.+?)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
            var match = re.Match(str);

            return match.Groups[2].Value;
        }
    }
}
