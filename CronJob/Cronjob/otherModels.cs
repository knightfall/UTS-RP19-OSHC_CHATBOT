using System;
using System.Collections.Generic;
using System.Text;

namespace Cronjob
{
    public class BaseQuote
    {
        public int duration { get; set; }
        public string Allianzadult { get; set; }
        public string Allianzchild { get; set; }
        public string NibCoverType { get; set; }
        public string medibankCoverType { get; set; }
        public double Quote { get; set; }
    }
    public class OshcPrice
    {
        public string AllianzQuote { get; set; }
        public string NibQuote { get; set; }
        public string MedibankQuote { get; set; }
        public string AhmQuote { get; set; }
    }
}
