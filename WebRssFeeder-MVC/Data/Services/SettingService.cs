using System.Xml;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TechTaskSec.Data.Services;

public interface ISettingService
{
    RssReaderSettings.RssReaderSettings GetRssReaderSettings();
    Task UpdateRssReaderSettings(string updateTimer, string rssuri);
}
public class SettingService : ISettingService
{
    private IConfiguration _configuration { get; }
    public SettingService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public RssReaderSettings.RssReaderSettings GetRssReaderSettings()
    {
        var rssSettings = new RssReaderSettings.RssReaderSettings()
        {
            UpdateTimer = _configuration["feederSettings:update"],
            RssUri = _configuration["feederSettings:rssLink"],
        };
        return rssSettings;
    }

    public async Task UpdateRssReaderSettings(string updateTimer, string rssuri)
    {
        XmlDocument settings = new XmlDocument();
        settings.Load("config.xml");
        if (!string.IsNullOrEmpty(updateTimer)) settings.GetElementsByTagName("update")[0].ChildNodes[0].Value = updateTimer;
        if (!string.IsNullOrEmpty(rssuri)) settings.GetElementsByTagName("rssLink")[0].ChildNodes[0].Value = rssuri;
        settings.Save("config.xml");
    }

   
}