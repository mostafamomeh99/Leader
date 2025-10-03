using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User
{
    public class UserViewModel
    {
        public string EmployeeNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstNameAr { get; set; }
        public string SecondNameAr { get; set; }
        public string ThirdNameAr { get; set; }
        public string LastNameAr { get; set; }

        public string FirstNameEn { get; set; }
        public string SecondNameEn { get; set; }
        public string ThirdNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Extension { get; set; }
        public string Age { get; set; }
        public string DateOfBirth { get; set; }
        public string JobDescription { get; set; }
        public string MaritalStatus { get; set; }
        public string UserName { get; set; }

        public List<string> RoleIds { get; set; }
        public List<Guid> ProjectIds { get; set; }
        public Guid? DefultProjectId { get; set; }
        public List<Guid> TeamIds { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}
