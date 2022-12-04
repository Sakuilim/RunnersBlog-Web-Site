using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Settings
{
    [ExcludeFromCodeCoverage]
    public class MongoDbSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}
