using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Posts.Queries.GetByIdPost
{
    public class GetByIdPostQuery : IRequest<Response<PostResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQuery, Response<PostResponse>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Response<PostResponse>> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
        {
            var result = _postRepository.GetByIdAsync(request.Id);
            Response<PostResponse> response = new();
            response.Data = _mapper.Map<PostResponse>(result);
            return response;
        }
    }

}
