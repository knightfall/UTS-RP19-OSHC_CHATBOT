namespace ChatbotAPI.Models
{
    public class MbsShortResult
    {
        public string ItemNum { get; set; }

        public string ItemStartdate { get; set; }

        public string ItemEnddate { get; set; }

        public string Category { get; set; }

        public string Group { get; set; }

        public string Subgroup { get; set; }

        public string Subheading { get; set; }

        public string ProviderType { get; set; }

        public string BenefitType { get; set; }

        public string FeeStartdate { get; set; }

        public decimal Schedulefee { get; set; }

        public decimal Benefit75 { get; set; }

        public decimal Benefit85 { get; set; }

        public decimal Benefit100 { get; set; }

        public string Description { get; set; }
    }
}