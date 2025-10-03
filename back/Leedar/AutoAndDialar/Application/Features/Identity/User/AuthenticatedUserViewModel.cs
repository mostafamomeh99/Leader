using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User
{
    public class AuthenticatedUserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool? IsMale { get; set; }
        public string GenderString { get; set; }
        public string Nationality { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string BirthdayDateString { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid RegistrationTypeId { get; set; }
        public List<Guid> Permissions { get; set; }
    }
}
