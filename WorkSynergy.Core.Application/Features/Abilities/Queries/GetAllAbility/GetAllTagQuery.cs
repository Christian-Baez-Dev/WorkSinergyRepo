using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Queries.GetAllAbilities
{
    public class GetAllAbilityQuery : IRequest<Response<IEnumerable<AbilityResponse>>>
    {
        public int Count { get; set; }
        public int Skip { get; set; }

    }

    public class GetAllPAbilityQueryHandler : IRequestHandler<GetAllAbilityQuery, Response<IEnumerable<AbilityResponse>>>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        public GetAllPAbilityQueryHandler(IAbilityRepository abilityRepository, IMapper mapper
            )
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<AbilityResponse>>> Handle(GetAllAbilityQuery request, CancellationToken cancellationToken)
        {
            var result = await _abilityRepository.GetAllAsync(request.Skip, request.Count);
            Response<IEnumerable<AbilityResponse>> response = new();
            response.Data = _mapper.Map<List<AbilityResponse>>(result);
            return response;
        }
    }

}
