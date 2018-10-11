using System;
using System.Text;

namespace CsharpLibrary
{
    public static class EncodingExtension
    {
        public static string ToBase64(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        public static string GetStringFromBase64(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            byte[] textAsBytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(textAsBytes);
        }
    }
}
