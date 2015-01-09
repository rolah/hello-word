using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contrib.PlacesField.ViewModel
{
    public class PlacesFieldViewModel
    {
        public string Name { get; set; }

        public string PostalCode { get; set; }

        public string Category { get; set; }

        public string PlaceName { get; set; }

        public string PlaceLatLong { get; set; }

        public bool ShowLink { get; set; }

        public bool ShowMap { get; set; }
    }
}