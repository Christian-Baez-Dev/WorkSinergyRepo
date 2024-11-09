using AutoMapper;
using MediatR;
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
        public string PaymentMethod { get; set; }
        public List<int> Categories { get; set; }
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
            var result = await _postRepository.CreateAsync(post);
            foreach (var item in request.Categories)
            {
                PostTags postTag = new PostTags { PostId = result.Id, TagId = item };
                await _postTagsRepository.CreateAsync(postTag);
            }
            return response;
        }
    }
}
