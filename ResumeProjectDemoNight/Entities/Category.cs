namespace ResumeProjectDemoNight.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Portfolio> Portfolios { get; set; } 
    }
}
