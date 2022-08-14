using WebRssFeeder_MVC.Models;

namespace WebRssFeeder_MVC.ViewModels;

public class ItemViewModel
{
    public List<ItemModel> ItemModels { get; set; }
    public string RssUpdateTimer { get; set; }
}