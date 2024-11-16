using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Tags.Queries.GetAllTag
{
    public class GetAllTagQuery : IRequest<Response<IEnumerable<TagResponse>>>
    {
        public int Count { get; set; }
        public int Skip { get; set; }
    }

    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, Response<IEnumerable<TagResponse>>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public GetAllTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TagResponse>>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _tagRepository.GetAllAsync(request.Skip, request.Count);
            if (result == null)
            {
                throw new ApiException("No Tags were found", StatusCodes.Status404NotFound);
            }
            Response<IEnumerable<TagResponse>> response = new();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = _mapper.Map<List<TagResponse>>(result);
            return response;
        }
    }

}
