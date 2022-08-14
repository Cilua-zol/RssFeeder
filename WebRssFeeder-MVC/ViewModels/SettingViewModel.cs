using System.ComponentModel.DataAnnotations;

namespace WebRssFeeder_MVC.ViewModels;

public class SettingViewModel
{
    [Display(Name = "RssUri")]
    [Required(ErrorMessage = "Name must match the format")]
    public string RssUri { get; set; } 
    
    
    [Display(Name = "UpdateTimer")]
    [Required(ErrorMessage = "Name must match the format")]
    public string UpdateTimer { get; set; }
}