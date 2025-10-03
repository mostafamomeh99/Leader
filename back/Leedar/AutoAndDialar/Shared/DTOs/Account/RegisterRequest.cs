namespace Shared.DTOs.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        public Guid RegisterationTypeId { get; set; }
        //[Required]
        public string FullNameAr { get; set; }
        //[Required]
        public string FullNameEn { get; set; }

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
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Extension { get; set; }
        public string Age { get; set; }
        public string DateOfBirth { get; set; }
        public string JobDescription { get; set; }
        public string MaritalStatus { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public List<string> RoleIds { get; set; }
        [Required]
        public List<Guid> ProjectIds { get; set; }
        public Guid? DefultProjectId { get; set; }
        //public List<Guid> PermissionIds { get; set; }


        public bool IsDomainUser { get; set; }
    }
}
