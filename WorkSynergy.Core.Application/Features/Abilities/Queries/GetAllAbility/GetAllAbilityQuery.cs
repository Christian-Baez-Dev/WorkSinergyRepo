using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.Exceptions;
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
            if (result == null || result.Count == 0) 
            {
                throw new ApiException("No abilities were found", StatusCodes.Status404NotFound);
            }
            response.Data = _mapper.Map<List<AbilityResponse>>(result);
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
