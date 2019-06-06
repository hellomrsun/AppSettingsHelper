using System;
using System.Configuration;
using System.Globalization;

namespace CsharpLibrary.AppSettings
{
    public class AppSettingsParser : IAppSettingsParser
    {
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"appSettings key({key}) does not exist");
            }

            var rawValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(rawValue))
            {
                throw new ArgumentNullException(key, $"appSettings key({key}) data could not be null or empty");
            }

            var type = typeof(T);

            T result;

            if (type.IsEnum)
            {
                result = (T)Enum.Parse(typeof(T), rawValue);
            }
            else
            {
                result = (T)Convert.ChangeType(rawValue, typeof(T), CultureInfo.InvariantCulture);
            }

            return result;
        }
    }
}
