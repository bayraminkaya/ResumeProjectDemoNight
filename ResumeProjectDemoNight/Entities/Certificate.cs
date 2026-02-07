namespace ResumeProjectDemoNight.Entities
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public string Name { get; set; }           
        public string Issuer { get; set; }         
        public string IssueDate { get; set; }      
        public string? CredentialUrl { get; set; } 
        public string? IconUrl { get; set; }       
        public bool Status { get; set; } = true;   
    }
}