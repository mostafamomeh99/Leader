using Application.Features.Identity.User;
using Domain.Entities.Identity;
using Shared.DTOs.Account;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
   public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> FormAuthenticateAsync(UserLoginViewModel request);

        Task<Response<AuthenticationResponse>> WindowsAuthenticateAsync(UserLoginViewModel request);

        Task<User> FindByNameAsync(string userName);
        Task<User> FindByEmailAsync(string email);


        Task<Response<string>> ForgotPassword(ForgotPasswordRequest model, string origin);

        Task<Response<string>> ResetPassword(ResetPasswordRequest model);

        //Task<List<UserViewModel>> GetAllAsLookupAsync(Guid projectId, bool isCached = false);

        Task<Response<string>> SignOutAsync(string userId);

        Task<Response<User>> RegisterAsync(RegisterRequest request);

        Response<RegisterRequest> GetActiveDirectoryUserByUserName(string userName);
    }
}
