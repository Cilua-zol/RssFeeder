using Microsoft.AspNetCore.Mvc;
using TechTaskSec.Data.Services;
using WebRssFeeder_MVC.ViewModels;

namespace WebRssFeeder_MVC.Controllers;

public class SettingController : Controller
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    [HttpGet]
    public IActionResult EditSetting()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EditSetting(SettingViewModel settingViewModel)
    {
        if (ModelState.IsValid)
        {                
            await _settingService.UpdateRssReaderSettings(settingViewModel.UpdateTimer, settingViewModel.RssUri);
            return RedirectToAction("Index", "Home");
        }

        return View(settingViewModel);
    }
}