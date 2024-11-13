using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
        private readonly IPostTagsRepository _postTagsRepository;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IPostTagsRepository postTagsRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postTagsRepository = postTagsRepository;
        }

        public async Task<Response<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var post = _mapper.Map<Post>(request);
            post.Abilities = new List<PostAbilities>();
            post.Tags = new List<PostTags>();

            var result = await _postRepository.CreateAsync(post);
            foreach (var item in request.Abilities)
            {
                PostAbilities postAbilities = new PostAbilities { PostId = result.Id, AbilityId = item };
                post.Abilities.Add(postAbilities);
            }
            foreach (var item in request.Categories)
            {
                PostTags postTag = new PostTags { PostId = result.Id, TagId = item };
                post.Tags.Add(postTag);
            }
            await _postRepository.UpdateAsync(post, post.Id);
            return response;
        }
    }
}
