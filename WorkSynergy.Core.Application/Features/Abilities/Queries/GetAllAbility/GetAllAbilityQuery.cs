﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Queries.GetAllAbilities
{
    public class GetAllAbilityQuery : IRequest<ManyAbilityResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllAbilityQueryHandler : IRequestHandler<GetAllAbilityQuery, ManyAbilityResponse>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        public GetAllAbilityQueryHandler(IAbilityRepository abilityRepository, IMapper mapper
            )
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<ManyAbilityResponse> Handle(GetAllAbilityQuery request, CancellationToken cancellationToken)
        {
            var result = await _abilityRepository.GetAllOrderAndPaginateAsync(null, null, false, request.PageNumber, request.PageSize);
            ManyAbilityResponse response = new();
            response.Data = _mapper.Map<List<AbilityResponse>>(result.Result);
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
