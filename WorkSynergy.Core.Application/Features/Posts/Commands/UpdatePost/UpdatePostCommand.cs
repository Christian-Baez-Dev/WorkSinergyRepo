using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.Features.Posts.Commands.CreatePost;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public List<int> Categories { get; set; }
        public List<int> DeleteCategories { get; set; }
    }
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IPostTagsRepository _postTagsRepository;

        public UpdatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IPostTagsRepository postTagsRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postTagsRepository = postTagsRepository;
        }

        public async Task<Response<int>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            response.Succeeded = true;
            var post = await _postRepository.GetByIdWithIncludeAsync(request.Id, new List<string> { "Tags" });
            post.Description = request.Description ?? post.Description;
            post.Currency = request.Currency ?? post.Currency;
            post.Title = request.Title ?? post.Title;

            await _postRepository.UpdateAsync(post, post.Id);

            for (int i = 0; i < post.Tags.Count(); i++)
            {
                var tag = post.Tags.ElementAt(i);
                if (!request.Categories.Contains(tag.TagId))
                {
                    await _postTagsRepository.DeleteAsync(tag);
                }
            }

            foreach (var item in request.Categories)
            {
                PostTags postTag = new PostTags { PostId = post.Id, TagId = item };
                await _postTagsRepository.CreateAsync(postTag);
            }

            return response;
        }
    }
}
