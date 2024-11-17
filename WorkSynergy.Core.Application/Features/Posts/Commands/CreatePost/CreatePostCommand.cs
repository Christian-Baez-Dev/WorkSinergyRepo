using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<Response<int>>
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string ContractOption { get; set; }
        //Aproximate budget
        public double From { get; set; }
        public double To { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Abilities { get; set; }
        public string CreatorUserId { get; set; }

    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IAbilityRepository _abilityRepository;

        private readonly ITagRepository _tagRepository;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IAbilityRepository abilityRepository, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _abilityRepository = abilityRepository;
            _tagRepository = tagRepository;
        }

        public async Task<Response<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var post = _mapper.Map<Post>(request);
            if (!Enum.TryParse(request.ContractOption, true, out ContractOptions enumResult))
            {
                throw new ApiException("Incorrect contract option provided", StatusCodes.Status400BadRequest);
            }
            post.Abilities = new List<PostAbility>();
            post.Tags = new List<PostTag>();
            post.ContractOptionId = (int)enumResult;

            foreach (var item in request.Abilities)
            {
                var ability = await _abilityRepository.GetByIdAsync(item);
                if (ability == null)
                {
                    throw new ApiException("Invalid tag provided", StatusCodes.Status400BadRequest);
                }
                PostAbility postAbilities = new PostAbility { PostId = post.Id, AbilityId = item };
                post.Abilities.Add(postAbilities);
            }
            foreach (var item in request.Categories)
            {
                var tag = await _tagRepository.GetByIdAsync(item);
                if (tag == null)
                {
                    throw new ApiException("Invalid tag provided", StatusCodes.Status400BadRequest);
                }

                PostTag postTag = new PostTag { PostId = post.Id, TagId = item };
                post.Tags.Add(postTag);
            }
            var result = await _postRepository.CreateAsync(post);
            if(result == null)
            {
                throw new ApiException("Error while creating the post", StatusCodes.Status500InternalServerError);
            }
            await _postRepository.UpdateAsync(post, post.Id);
            response.Succeeded = true;
            response.Data = post.Id;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
    }
}
