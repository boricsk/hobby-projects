using System.Globalization;

namespace _026_ToJadenCase
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ToJadenCase("test test2");
        }
        public static string ToJadenCase(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                return phrase;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(phrase.ToLower());
        }
    }
}
