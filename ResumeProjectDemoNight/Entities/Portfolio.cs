namespace ResumeProjectDemoNight.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string ProjectTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Description { get; set; }
        public string TechStack { get; set; }
        public string GithubUrl { get; set; }
        public string OtherImages { get; set; }
    }
}
