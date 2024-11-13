using AutoMapper;
using MediatR;
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
        private readonly IPostTagsRepository _postTagsRepository;

        public DeletePostCommandHandler(IMapper mapper, IPostRepository postRepository, IPostTagsRepository postTagsRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postTagsRepository = postTagsRepository;
        }

        public async Task<Response<int>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            response.Succeeded = true;
            var post = await _postRepository.GetByIdAsync(request.Id);
            await _postRepository.DeleteAsync(post);

            return response;
        }
    }

}
