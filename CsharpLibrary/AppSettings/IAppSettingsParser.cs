namespace CsharpLibrary.AppSettings
{
    public interface IAppSettingsParser
    {
        T Get<T>(string key);
    }
}