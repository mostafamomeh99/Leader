using Shared.DTOs.LDAB;
using Shared.Interfaces.Services;
using Shared.Settings;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.LDAB
{
    public class LDABService : ILDABService
    {
        private readonly LDABSettings _ldabSettings;
        public LDABService(LDABSettings ldabSettings)
        {
            _ldabSettings = ldabSettings;
        }

        public Response<UserModel> Login(LoginModel model)
        {
            if (string.IsNullOrEmpty(model.DomainName))
            {
                model.DomainName = _ldabSettings.DomainName;
            }
            return GetActiveDirectoryUserData(model.DomainName, model.UserName, model.Password);
        }
        public Response<UserModel> CheckIfExist(UserExistedModel model)
        {
            model.DomainName = _ldabSettings.DomainName;
            model.DomainUserName = _ldabSettings.UserName;
            model.DomainPassword = _ldabSettings.Password;


            Response<UserModel> result = new();
            try
            {
                PrincipalContext context = new(ContextType.Domain, model.DomainName, model.DomainUserName, model.DomainPassword);
                UserPrincipal prUsr = UserPrincipal.FindByIdentity(context, model.UserName);

                if (prUsr != null)
                {
                    int startIndex = prUsr.DistinguishedName.IndexOf("OU=", 1, StringComparison.Ordinal) + 3;
                    int endIndex = prUsr.DistinguishedName.IndexOf(",", startIndex, StringComparison.Ordinal);
                    var department = prUsr.DistinguishedName.Substring((startIndex), (endIndex - startIndex));
                    result.Data = new UserModel
                    {
                        UserName = prUsr.SamAccountName,
                        Email = prUsr.EmailAddress,
                        DisplayName = prUsr.DisplayName,
                        Department = department,
                        LastChangePassword = prUsr.LastPasswordSet.ToString(),
                        LastLogin = prUsr.LastLogon.ToString()
                    };
                    result.Message = new NotificationMessage
                    {
                        Title = "User Is Founded",
                    };
                    result.Succeeded = true;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                }
                else
                {
                    result.Message = new NotificationMessage
                    {
                        Title = "User Not Founded",
                    };
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "Exception",
                };
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            return result;
        }
        private Response<UserModel> GetActiveDirectoryUserData(string domainName, string username, string password)
        {
            Response<UserModel> result = new();
           
            try
            {
                PrincipalContext context = new(ContextType.Domain, domainName, username, password);
                bool bValid = context.ValidateCredentials(username, password);

                if (bValid)
                {
                    UserPrincipal prUsr = UserPrincipal.FindByIdentity(context, username);

                    if (prUsr != null)
                    {
                        int startIndex = prUsr.DistinguishedName.IndexOf("OU=", 1, StringComparison.Ordinal) + 3;
                        int endIndex = prUsr.DistinguishedName.IndexOf(",", startIndex, StringComparison.Ordinal);
                        var department = prUsr.DistinguishedName.Substring((startIndex), (endIndex - startIndex));

                        result.Data = new UserModel
                        {
                            UserName = prUsr.SamAccountName,
                            Email = prUsr.EmailAddress,
                            DisplayName = prUsr.DisplayName,
                            Department = department,
                            LastChangePassword = prUsr.LastPasswordSet.ToString(),
                            LastLogin = prUsr.LastLogon.ToString()
                        };
                        result.Message = new NotificationMessage
                        {
                            Title = "User Is Founded",
                        };
                        result.Succeeded = true;
                        result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                    }
                    else
                    {
                        result.Message = new NotificationMessage
                        {
                            Title = "User Not Founded",
                        };
                        result.Succeeded = false;
                        result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {

                    result.Message = new NotificationMessage
                    {
                        Title = "Exception",
                        Body = "Please enter valid UserName/Password.",
                    };
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }

            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "Exception",
                };
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }

            return result;
        }


    }
}
