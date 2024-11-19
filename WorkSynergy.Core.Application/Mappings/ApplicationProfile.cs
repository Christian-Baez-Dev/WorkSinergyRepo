using AutoMapper;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Features.Abilities.Commands.CreateAbilitiesCommand;
using WorkSynergy.Core.Application.Features.Abilities.Commands.UpdateAbility;
using WorkSynergy.Core.Application.Features.JobApplications.Commands;
using WorkSynergy.Core.Application.Features.Posts.Commands.CreatePost;
using WorkSynergy.Core.Application.Features.Posts.Commands.UpdatePost;
using WorkSynergy.Core.Application.Features.Tags.Commands.CreateTagCommand;
using WorkSynergy.Core.Application.Features.Tags.Commands.UpdateTag;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile() 
        {
            #region Post
            CreateMap<Post, PostResponse>()
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
            //CreateMap<Post, PostResponse>()
            //    .ReverseMap();
            //CreateMap<UpdatePostCommand, Post>()
            //    .ReverseMap()
            //    .ForMember(x => x.Categories, opt => opt.Ignore())
            //    .ForMember(x => x.DeleteCategories, opt => opt.Ignore());

            CreateMap<CreateJobApplicationCommand, JobApplication>()
                .ReverseMap();
            #endregion

            #region Ability
            CreateMap<Ability, AbilityResponse>()
                .ReverseMap();
            CreateMap<UpdateAbilityCommand, Ability>()
                .ReverseMap();
            CreateMap<CreateAbilityCommand, Ability>()
                .ReverseMap();
            #endregion


            #region Tags
            CreateMap<Tag, TagResponse>()
                .ReverseMap();
            CreateMap<UpdateTagCommand, Tag>()
                .ReverseMap();
            CreateMap<CreateTagCommand, Tag>()
                .ReverseMap();
            #endregion
        }

    }
}
