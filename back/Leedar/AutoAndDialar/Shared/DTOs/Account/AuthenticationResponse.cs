namespace Shared.DTOs.Account
{
    using System;
    using System.Collections.Generic;

    public class AuthenticationResponse
    {

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Roles { get; set; }
        public List<Guid> PermessionIds { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public Guid DefualtUserProjectId { get; set; }

    }
}
