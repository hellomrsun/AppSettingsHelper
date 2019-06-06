using System;
using CsharpLibrary.Enums;

namespace CsharpLibrary.AppSettings
{
    public class AppSettingsRetriever : IAppSettingsRetriever
    {
        private readonly IAppSettingsParser _appSettingsParser;

        public AppSettingsRetriever(IAppSettingsParser appSettingsParser)
        {
            _appSettingsParser = appSettingsParser;
        }

        public string StringValue
        {
            get
            {
                return _appSettingsParser.Get<string>(AppSettingsConstants.StringKey);
            }
        }

        public int IntValue
        {
            get
            {
                return _appSettingsParser.Get<int>(AppSettingsConstants.IntKey);
            }
        }

        public DateTime DateValue
        {
            get
            {
                return _appSettingsParser.Get<DateTime>(AppSettingsConstants.DateKey);
            }
        }

        public Furniture EnumValue
        {
            get
            {
                return _appSettingsParser.Get<Furniture>(AppSettingsConstants.EnumKey);
            }
        }
    }
}