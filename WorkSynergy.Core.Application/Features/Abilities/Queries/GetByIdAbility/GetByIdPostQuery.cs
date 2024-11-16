﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Queries.GetByIdAbilities
{
    public class GetByIdAbilityQuery : IRequest<Response<AbilityResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdAbilityQueryHandler : IRequestHandler<GetByIdAbilityQuery, Response<AbilityResponse>>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        public GetByIdAbilityQueryHandler(IAbilityRepository abilityRepository, IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<Response<AbilityResponse>> Handle(GetByIdAbilityQuery request, CancellationToken cancellationToken)
        {
            var result = await _abilityRepository.GetByIdAsync(request.Id);
            if (result == null) 
            {
                throw new ApiException("No ability were found", StatusCodes.Status404NotFound);
            }
            Response<AbilityResponse> response = new();
            response.Succeeded = true;
            response.Data = _mapper.Map<AbilityResponse>(result);
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
