using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechTaskSec.Data.Services;
using WebRssFeeder_MVC.Models;
using WebRssFeeder_MVC.ViewModels;

namespace WebRssFeeder_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRssService _rssService;
    private readonly ISettingService _settingService;

    public HomeController(ILogger<HomeController> logger, IRssService rssService, ISettingService settingService)
    {
        _settingService = settingService;
        _rssService = rssService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var settings = _settingService.GetRssReaderSettings();
        var itemModels = new ItemViewModel()
        {
            ItemModels = await _rssService.RssReader(settings.RssUri),
            RssUpdateTimer = settings.UpdateTimer
        };
        return View(itemModels);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}