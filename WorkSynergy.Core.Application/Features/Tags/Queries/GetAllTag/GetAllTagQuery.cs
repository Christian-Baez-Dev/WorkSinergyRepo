using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Tags.Queries.GetAllTag
{
    public class GetAllTagQuery : IRequest<ManyTagsResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, ManyTagsResponse>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public GetAllTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<ManyTagsResponse> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _tagRepository.GetAllOrderAndPaginateAsync(null, null, false, request.PageNumber, request.PageSize);

            ManyTagsResponse response = new();

            response.Data = _mapper.Map<List<TagResponse>>(result.Result);
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
