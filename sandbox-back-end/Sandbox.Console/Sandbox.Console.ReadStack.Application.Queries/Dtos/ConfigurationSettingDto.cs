namespace Sandbox.Console.ReadStack.Application.Queries.Dtos
{
    public class ConfigurationSettingDto
    {
        public ConfigurationSettingDto(string key, string path, string value)
        {
            Key = key;
            Path = path;
            Value = value;
        }

        public string Key { get; }
        public string Path { get; }
        public string Value { get; }
    }
}