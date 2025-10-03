//using Application.Common.Interfaces;
//using AutoMapper;
//using Infrastructure.Interfaces;
//using Localization;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Shared.DTOs.LDAB;
//using Shared.Interfaces.Services;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Identity.User.Queries
//{
//    public class CheckNameForDomain : IRequest<Response<UserModel>>
//    {
//        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "RequiredFieldMessage")]
//        [Display(Name = "UserName", ResourceType = typeof(SharedResource))]
//        public string UserName { get; set; }
//    }
//    public class CheckNameForDomainHandler : IRequestHandler<CheckNameForDomain, Response<UserModel>>
//    {
//        private readonly IMapper _mapper;
//        private readonly IApplicationDbContext _context;
//        private readonly ILDABService _LDABService;
//        //private readonly Ima _LDABService;
//        //private readonly UserManager<Domain.Entities.Identity.User> _userManager;

//        public CheckNameForDomainHandler(
//            IMapper mapper,
//            IApplicationDbContext context,
//          ILDABService LDABService
//            //,UserManager<Domain.Entities.Identity.User> userManager
//            )
//        {
//            _mapper = mapper;
//            _context = context;
//            _LDABService = LDABService;
//        }
//        public async Task<Response<UserModel>> Handle(CheckNameForDomain request, CancellationToken cancellationToken)
//        {
//            Response<UserModel> result = new();
//            try
//            {
//                var modelToCheck = _mapper.Map<UserExistedModel>(request);
//                var isAvailbaleInDomain = _LDABService.CheckIfExist(modelToCheck);
//                if (isAvailbaleInDomain.Succeeded)
//                {
//                    var windowsUserName = "Domain_" + request.UserName;
//                    var isExistedInSystem = await _context.User.FirstOrDefaultAsync(x => x.UserName == windowsUserName);
//                    if (isExistedInSystem != null)
//                    {
//                        result.Succeeded = false;
//                        result.HttpStatusCode = System.Net.HttpStatusCode.OK;
//                        result.Data = isAvailbaleInDomain.Data;
//                        result.Message = new NotificationMessage
//                        {
//                            Title = $"User {isExistedInSystem.PersonalInfo.FullNameAr} is Existed In the System",
//                            Body = $"User {isExistedInSystem.PersonalInfo.FullNameAr}"
//                        };
//                    }
//                    else
//                    {
//                        result = isAvailbaleInDomain;
//                    }
//                }
//                else
//                {
//                    result.Exception = isAvailbaleInDomain.Exception;
//                    result.Message = new NotificationMessage
//                    {
//                        Title = $"Username {request.UserName} is not Existed In Domain",
//                        Body = $"Username {request.UserName} "
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
//                result.Exception = ex;
//            }
//            return result;
//        }
//    }
//}
