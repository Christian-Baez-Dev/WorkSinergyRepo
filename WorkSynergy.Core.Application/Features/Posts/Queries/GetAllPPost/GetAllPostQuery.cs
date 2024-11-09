using AutoMapper;
using MediatR;
using System.Collections.Generic;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPPost
{
    public class GetAllPostQuery : IRequest<Response<IEnumerable<PostResponse>>>
    {
        public int Page { get; set; }
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
            var result = await _postRepository.GetAllAsync();
            Response<IEnumerable<PostResponse>> response = new();
            response.Data = _mapper.Map<List<PostResponse>>(result);
            return response;
        }
    }

}
