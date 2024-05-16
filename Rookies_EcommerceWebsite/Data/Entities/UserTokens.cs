namespace Rookies_EcommerceWebsite.Data.Entities
{
    public class UserTokens
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validaty { get; set; }
        public string RefreshToken { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
