using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WebRssFeeder_MVC.Models;

namespace TechTaskSec.Data.Services
{
    public interface IRssService
    {
        Task<List<ItemModel>> RssReader(string rssUri);
      
    }

    public class RssService : IRssService
    {
        public async Task<List<ItemModel>> RssReader(string rssUri)
        {
            try
            {
                List<ItemModel> itemModelList = new List<ItemModel>();
                XmlReader reader = XmlReader.Create(rssUri);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                foreach (SyndicationItem item in feed.Items)
                {
                    ItemModel itemModel = new ItemModel()
                    {
                        ItemTitle = item.Title.Text,
                        ItemDescription = Regex.Replace(item.Summary.Text,@"[</p>]", string.Empty),
                        ItemUri = item.Links[0].Uri.ToString(),
                        ItemPubDate = item.PublishDate.ToString().Substring(0,  item.PublishDate.ToString().IndexOf('+'))
                    };
                    itemModelList.Add(itemModel);
                }

                return itemModelList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}