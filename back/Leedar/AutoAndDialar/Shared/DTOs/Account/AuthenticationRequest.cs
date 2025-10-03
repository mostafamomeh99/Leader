namespace Shared.DTOs.Account
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDomainUser { get; set; }
    }
}