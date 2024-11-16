using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

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
            if (result == null)
            {
                throw new ApiException("No post were found", StatusCodes.Status404NotFound);
            }
            Response<PostResponse> response = new();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = _mapper.Map<PostResponse>(result);
            return response;
        }
    }

}
