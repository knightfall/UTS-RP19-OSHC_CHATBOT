using System;
using System.Collections.Generic;

namespace Cronjob
{
    public partial class Schedule
    {
        public string ItemNum { get; set; }
        public string SubItemNum { get; set; }
        public DateTime? ItemStartDate { get; set; }
        public DateTime? ItemEndDate { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string SubHeading { get; set; }
        public string ItemType { get; set; }
        public string FeeType { get; set; }
        public string ProviderType { get; set; }
        public string NewItem { get; set; }
        public string ItemChange { get; set; }
        public string AnaesChange { get; set; }
        public string DescriptorChange { get; set; }
        public string FeeChange { get; set; }
        public string Emsnchange { get; set; }
        public string Emsncap { get; set; }
        public string BenefitType { get; set; }
        public DateTime? BenefitStartDate { get; set; }
        public DateTime? FeeStartDate { get; set; }
        public decimal? ScheduleFee { get; set; }
        public decimal? Benefit75 { get; set; }
        public decimal? Benefit85 { get; set; }
        public decimal? Benefit100 { get; set; }
        public decimal? BasicUnits { get; set; }
        public DateTime? EmsnstartDate { get; set; }
        public DateTime? EmsnendDate { get; set; }
        public decimal? EmsnfixedCapAmount { get; set; }
        public decimal? EmsnpercentageCap { get; set; }
        public decimal? EmsnmaximumCap { get; set; }
        public string Emsndescription { get; set; }
        public DateTime? EmsnchangeDate { get; set; }
        public DateTime? DerivedFeeStartDate { get; set; }
        public string DerivedFee { get; set; }
        public string Anaes { get; set; }
        public DateTime? DescriptionStartDate { get; set; }
        public string Description { get; set; }
        public DateTime? QfestartDate { get; set; }
        public DateTime? QfeendDate { get; set; }
    }
}
