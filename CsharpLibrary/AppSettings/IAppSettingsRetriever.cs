using System;
using CsharpLibrary.Enums;

namespace CsharpLibrary.AppSettings
{
    public interface IAppSettingsRetriever
    {
        string StringValue { get; }
        int IntValue { get; }
        DateTime DateValue { get; }
        Furniture EnumValue { get; }
    }
}