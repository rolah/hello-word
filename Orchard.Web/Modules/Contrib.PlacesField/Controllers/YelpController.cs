using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;
using YelpSharp.Data.Options;

namespace Contrib.PlacesField.Controllers
{
    public class YelpController : Controller
    {
        private readonly Yelp _client;

        public YelpController()
        {
            var options = new Options()
            {
                AccessToken = "<YOUR_ACCESS_TOKEN>",
                AccessTokenSecret = "<YOUR_ACCESS_TOKEN_SECRET>",
                ConsumerKey = "<YOUR_ACCESS_CONSUMER_KEY>",
                ConsumerSecret = "<YOUR_CONSUMER_SECRET>"
            };

            _client = new Yelp(options);
        }

        public YelpController(Yelp client)
        {
            _client = client;
        }

        public ActionResult Places(string postalCode, string category, string term)
        {
            var so = new SearchOptions()
            {
                LocationOptions = new LocationOptions()
                {
                    location = postalCode
                },
                GeneralOptions = new GeneralOptions()
                {
                    category_filter = category,
                    term = term
                }
            };
            var results = _client.Search(so).Result;
            return Json(results.businesses.Select(
            p => new
            {
                value = p.location.coordinate.latitude + "~"
                    + p.location.coordinate.longitude,
                label = p.name
            }).ToArray()
            , JsonRequestBehavior.AllowGet);
        }

        public ActionResult Categories(string postalCode, string categories, string term)
        {
            var categoryList = new List<string> { 
                "Restaurants", "Nightlie", "Arts"
            };

            var results = string.IsNullOrEmpty(term) ?
                categoryList : categoryList.Where(c => c.ToLower().Contains(term.ToLower()));
            return Json(results.Select(c => new { value = c.ToLower(), label = c }).ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}