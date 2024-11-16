using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPPost
{
    public class GetAllPostQuery : IRequest<Response<IEnumerable<PostResponse>>>
    {
        public int Count { get; set; }
        public int Skip { get; set; }

    }

    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, Response<IEnumerable<PostResponse>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PostResponse>>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetAllAsync(request.Skip, request.Count);
            if (result == null)
            {
                throw new ApiException("No posts were found", StatusCodes.Status404NotFound);
            }
            Response<IEnumerable<PostResponse>> response = new();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = _mapper.Map<List<PostResponse>>(result);
            return response;
        }
    }

}
