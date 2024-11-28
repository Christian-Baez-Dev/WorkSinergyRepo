using AutoMapper;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.DTOs.Entities.ContractOption;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.FixedPriceMilestone;
using WorkSynergy.Core.Application.DTOs.Entities.HourlyMilestone;
using WorkSynergy.Core.Application.DTOs.Entities.JobApplication;
using WorkSynergy.Core.Application.DTOs.Entities.JobOffer;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.DTOs.Entities.UserAbility;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Features.Abilities.Commands.CreateAbilitiesCommand;
using WorkSynergy.Core.Application.Features.Abilities.Commands.UpdateAbility;
using WorkSynergy.Core.Application.Features.JobApplications.Commands.CreateJobApplication;
using WorkSynergy.Core.Application.Features.JobOffers.Commands.CreateJobOfferCommand;
using WorkSynergy.Core.Application.Features.Posts.Commands.CreatePost;
using WorkSynergy.Core.Application.Features.Posts.Commands.UpdatePost;
using WorkSynergy.Core.Application.Features.Tags.Commands.CreateTagCommand;
using WorkSynergy.Core.Application.Features.Tags.Commands.UpdateTag;
using WorkSynergy.Core.Application.Features.UserAbilities.Commands.CreateUserAbility;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            #region Post
            CreateMap<Post, PostResponse>()
                .ForMember(x => x.ApplicationsCount, opt => opt.MapFrom(x => x.Applications.Count))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.CreatedAt)))
                .ReverseMap();
            CreateMap<UpdatePostCommand, Post>()
                .ReverseMap()
                .ForMember(x => x.Categories, opt => opt.Ignore())
                .ForMember(x => x.DeleteCategories, opt => opt.Ignore());

            CreateMap<CreatePostCommand, Post>()
                .ForMember(x => x.Abilities, opt => opt.Ignore())
                .ForMember(x => x.ContractOption, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Categories, opt => opt.Ignore())
                .ForMember(x => x.Abilities, opt => opt.Ignore());
            #endregion
            #region Job Application
            CreateMap<JobApplication, JobApplicationResponse>()
                .ReverseMap();
            //CreateMap<UpdatePostCommand, Post>()
            //    .ReverseMap()
            //    .ForMember(x => x.Categories, opt => opt.Ignore())
            //    .ForMember(x => x.DeleteCategories, opt => opt.Ignore());

            CreateMap<CreateJobApplicationCommand, JobApplication>()
                .ReverseMap();
            #endregion
            #region Contract Option
            CreateMap<ContractOption, ContractOptionResponse>()
                .ReverseMap();

            //CreateMap<UpdatePostCommand, Post>()
            //    .ReverseMap()
            //    .ForMember(x => x.Categories, opt => opt.Ignore())
            //    .ForMember(x => x.DeleteCategories, opt => opt.Ignore());

            //CreateMap<CreateJobApplicationCommand, JobApplication>()
            //    .ReverseMap();
            #endregion


            #region Ability
            CreateMap<Ability, AbilityResponse>()
                .ReverseMap();
            CreateMap<PostAbility, AbilityResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Ability.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AbilityId))
                .ReverseMap();
            CreateMap<UpdateAbilityCommand, Ability>()
                .ReverseMap();
            CreateMap<CreateAbilityCommand, Ability>()
                .ReverseMap();
            #endregion
            #region User Ability
            CreateMap<UserAbility, UserAbilityResponse>()
                .ReverseMap();
            //CreateMap<UpdateAbilityCommand, Ability>()
            //    .ReverseMap();
            CreateMap<CreateUserAbilityCommand, UserAbility>()
                .ReverseMap();
            #endregion

            #region Tags
            CreateMap<Tag, TagResponse>()
                .ReverseMap();
            CreateMap<PostTag, TagResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Tag.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.TagId))
                .ReverseMap();
            CreateMap<UpdateTagCommand, Tag>()
                .ReverseMap();
            CreateMap<CreateTagCommand, Tag>()
                .ReverseMap();
            #endregion
            #region Currencies
            CreateMap<Currency, CurrencyResponse>()
                .ReverseMap();

            #endregion

            #region JobOffer
            CreateMap<JobOffer, JobOfferResponse>()
                .ReverseMap();
            CreateMap<CreateJobOfferCommand, JobOffer>()
                .ReverseMap();
            #endregion
            #region Contract
            CreateMap<Contract, ContractResponse>()
                .ReverseMap();
            #endregion
            #region Fixed price milestone
            CreateMap<FixedPriceMilestone, FixedPriceMilestoneResponse>()
                .ReverseMap();

            #endregion
            #region Hourly milestone
            CreateMap<HourlyMilestone, HourlyMilestonResponse>()
                .ForMember(x => x.Deliverables, opt => opt.MapFrom(x => x.Deliverables.Select(x => x.FilePath)))
                .ReverseMap();
            #endregion

        }

    }
}
