using System;
using System.Collections.Generic;

namespace Cronjob
{
    public partial class PostcodesGeo
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
