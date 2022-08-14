using System.ComponentModel.DataAnnotations;

namespace WebRssFeeder_MVC.Models;

public class ItemModel
{
    [Required]
    public string ItemTitle { get; set; }
    [Required]
    public string ItemDescription { get; set; }
    [Required]
    public string ItemPubDate { get; set; }
    [Required]
    public string ItemUri { get; set; }
}