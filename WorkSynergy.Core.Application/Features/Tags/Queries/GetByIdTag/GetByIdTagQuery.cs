using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Tags.Queries.GetByIdTag
{
    public class GetByIdTagQuery : IRequest<Response<TagResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQuery, Response<TagResponse>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetByIdTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Response<TagResponse>> Handle(GetByIdTagQuery request, CancellationToken cancellationToken)
        {
            var result = _tagRepository.GetByIdAsync(request.Id);
            Response<TagResponse> response = new();
            response.Data = _mapper.Map<TagResponse>(result);
            return response;
        }
    }

}
