using AutoMapper;
using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.ViewModels.Account;
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

        }



    }
}
