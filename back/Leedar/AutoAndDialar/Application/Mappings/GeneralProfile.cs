using Application.Features.Application.ScheduledCall;
using AutoMapper;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Domain.Entities.Lookup;
using Shared.DTOs.LDAB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //CreateMap<Features.Identity.User.Queries.CheckNameForDomain, UserExistedModel>().ReverseMap();
            //CreateMap<Features.Identity.User.Queries.LoginApplicationCommand, LoginModel>().ReverseMap();
            //CreateMap<Features.Identity.User.Queries.LoginDomainCommand, LoginModel>().ReverseMap();


            CreateMap<Features.Identity.User.Commands.Update.EditUserCommand, User>().ReverseMap();
            CreateMap<Features.Identity.User.Commands.Update.EditUserCommand, PersonalInfo>().ReverseMap();
            CreateMap<Features.Lookup.Campaign.Commands.Create.CreateNewCampaignCommand, Campaign>().ReverseMap();
            CreateMap<Features.Lookup.Campaign.Commands.EditCampaignCommand, Campaign>().ReverseMap();

            CreateMap<Features.Lookup.Category.Commands.Create.CreateNewCategoryCommand, Category>().ReverseMap();
            CreateMap<Features.Lookup.Category.Commands.EditCategoryCommand, Category>().ReverseMap();



            CreateMap<Features.Application.Contact.Commands.Create.CreateNewContactCommand, Contact>().ReverseMap();
            CreateMap<Features.Application.Contact.Commands.EditContactCommand, Contact>().ReverseMap();

           // CreateMap<Features.Application.HistoricalCall.Commands.CreateNewHistoricalCallCommand, HistoricalCall>().ReverseMap();
            CreateMap<Features.Application.ScheduledCall.Commands.CreateNewScheduledCallCommand, ScheduledCall>().ReverseMap();
            CreateMap<Features.Identity.User.Commands.Update.EditUserCommand, User>().ReverseMap();
            CreateMap<Features.Identity.User.Commands.Update.EditUserCommand, PersonalInfo>().ReverseMap();

            CreateMap<Features.Application.PersonalInfo.Commands.Update.EditPersonalInfoCommand, Features.Identity.User.Commands.Update.EditUserCommand>().ReverseMap();

            CreateMap<Features.Application.PersonalInfo.Commands.Update.EditPersonalInfoCommand, PersonalInfo>().ReverseMap();
         
            CreateMap<Features.Identity.Role.Commands.CreateNewRoleCommand, Role>().ReverseMap();
            CreateMap<Features.Identity.Role.Commands.EditRoleCommand, Role>().ReverseMap();

           


           
            CreateMap<ScheduledCallVM, ScheduledCall>().ReverseMap();



           
            //CreateMap<Application.Features.Identity.User.UserVM, PersonalInfo>().ReverseMap();




        }
    }
}
