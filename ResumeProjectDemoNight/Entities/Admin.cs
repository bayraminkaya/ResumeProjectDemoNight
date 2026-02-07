namespace ResumeProjectDemoNight.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}