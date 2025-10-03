using Domain.Entities.Lookup;



namespace Domain.Entities.Identity
{
    public class UserTeams
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }


        public virtual  User? User { get; set; }
        public virtual  Team? Team { get; set; }
    }
}
