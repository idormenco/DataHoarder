namespace DataHoarder.Modules.Air.Core.Options
{
    public class AirModuleOptions
    {
        public string ProviderUrl { get; set; }
        public bool CachingEnabled { get; set; }
        public int CacheExpirationInSeconds { get; set; }
        public string BackgroundJobCronExpression { get; set; }
    }
}
