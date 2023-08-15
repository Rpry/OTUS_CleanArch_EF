namespace WebApi.Settings
{
    public class ApplicationSettings
    {
        public string ConnectionString { get; set; }
        
        public RmqSettings RmqSettings { get; set; }
    }
}