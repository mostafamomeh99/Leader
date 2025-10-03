using Shared.DTOs.LDAB;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Services
{
    public interface ILDABService
    {
        Response<UserModel> Login(LoginModel model);
        Response<UserModel> CheckIfExist(UserExistedModel model);
    }
}
