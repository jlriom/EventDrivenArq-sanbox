namespace Sandbox.Shared.Api.Configuration
{
    public static class ConfigurationKeys
    {
        public const string ApplicationInsightsInstrumentationKey = "ApplicationInsights:InstrumentationKey";
        public const string SystemSqlConnectionStringName = "SystemDb";

        public const string BlobSqlConnectionStringName = "ConnectionStrings:BlobDb";
        public const string UserSqlConnectionStringName = "ConnectionStrings:UserDb";
        public const string DocSqlConnectionStringName = "ConnectionStrings:DocDb";
        public const string DocPortalUrl = "Urls:DocPortal";
        public const string AdminPortalUrl = "Urls:AdminPortal";
        public const string AuthorityUrl = "Urls:Authority";
        public const string BlobApiUrl = "Urls:BlobApi";
        public const string ConsoleApiUrl = "Urls:ConsoleApi";
        public const string DocApiUrl = "Urls:DocApi";
        public const string EMailerApiUrl = "Urls:EMailerApi";
        public const string NotifierApiUrl = "Urls:NotifierApi";
        public const string UsrApiUrl = "Urls:UsrApi";
    }
}
