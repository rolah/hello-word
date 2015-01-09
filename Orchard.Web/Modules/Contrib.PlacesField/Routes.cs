using Orchard.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Contrib.PlacesField
{
    public class Routes : IRouteProvider
    {
        

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[]{
                new RouteDescriptor{
                Priority = 5,
                Route = new Route(
                    "Admin/PlacesField/{controller}/{action}",
                    new RouteValueDictionary{
                    {"area", "Contrib.PlaceField"},
                    {"controller", "Yelp"},
                    {"action","Places"}                    
                    },
                    new RouteValueDictionary(),
                    new RouteValueDictionary{
                        {"area", "Contrib.PlacesField"}
                    },
                    new MvcRouteHandler())                
                }   
           };
        }
    }
}