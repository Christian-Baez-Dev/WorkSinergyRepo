using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IPostTagRepository _postTagsRepository;

        public DeletePostCommandHandler(IMapper mapper, IPostRepository postRepository, IPostTagRepository postTagsRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postTagsRepository = postTagsRepository;
        }

        public async Task<Response<int>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var post = await _postRepository.GetByIdAsync(request.Id);
            if (post == null)
            {
                throw new ApiException("Post not found", StatusCodes.Status404NotFound);
            }
            await _postRepository.DeleteAsync(post);

            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }

}
