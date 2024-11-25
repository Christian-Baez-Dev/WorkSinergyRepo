using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPostByUserId
{
    public class GetAllPostByUserIdQuery : IRequest<ManyPostsResponse>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Id { get; set; }
    }

    public class GetAllPostByUserIdQueryHandler : IRequestHandler<GetAllPostByUserIdQuery, ManyPostsResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostByUserIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<ManyPostsResponse> Handle(GetAllPostByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetAllOrderAndPaginateAsync(x => x.CreatorUserId == request.Id, null, false, request.PageNumber, request.PageSize, x => x.Abilities, x => x.ContractOption, x => x.Tags, x => x.Applications, x => x.Currency);
     

            ManyPostsResponse response = new();
            if (result.Result == null || result.Result.Count == 0)
            {
                throw new ApiException("No post were found", StatusCodes.Status404NotFound);
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
