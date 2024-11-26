using AutoMapper;
using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.UserAbility;
using WorkSynergy.Core.Application.Features.UserAbilities.Commands.CreateUserAbility;
using WorkSynergy.Core.Application.ViewModels.Account;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Identity.Models;

namespace RealEstateApp.Infrastructure.Identity.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {



            CreateMap<WorkSynergyUser, UserViewModel>()
                .ReverseMap();

            CreateMap<WorkSynergyUser, SaveUserViewModel>()
                .ReverseMap();

            CreateMap<WorkSynergyUser, UserDTO>()
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #region User Ability
            CreateMap<UserAbility, AbilityResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Ability.Name))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Ability.Id));
            #endregion

        }



    }
}
