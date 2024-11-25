using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQuery : IRequest<ManyPostsResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, ManyPostsResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<ManyPostsResponse> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetAllOrderAndPaginateAsync(null, null, false, request.PageNumber, request.PageSize, x => x.Abilities, x => x.ContractOption, x => x.Tags, x => x.Applications, x => x.Currency);
            if (result.Result == null)
            {
                throw new ApiException("No posts were found", StatusCodes.Status404NotFound);
            }

            ManyPostsResponse response = new();
            if (result.Result == null || result.Result.Count == 0)
            {
                throw new ApiException("No abilities were found", StatusCodes.Status404NotFound);
            }
            response.Data = _mapper.Map<List<PostResponse>>(result.Result);
            response.TotalPages = result.TotalPages;
            response.HasPrevious = result.HasPrevious;
            response.HasNext = result.HasNext;
            response.PageNumber = request.PageNumber;
            response.TotalCount = result.TotalCount;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
