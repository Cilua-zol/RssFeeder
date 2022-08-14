using Microsoft.Extensions.Configuration;

namespace TechTaskSec.Data.Services.RssReaderSettings
{
    public class RssReaderSettings
    {
        public string RssUri { get; set; }
        public string UpdateTimer { get; set; }
    }
}