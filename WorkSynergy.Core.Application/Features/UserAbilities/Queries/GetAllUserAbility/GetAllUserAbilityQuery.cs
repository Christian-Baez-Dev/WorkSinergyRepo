using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.UserAbility;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.UserAbilities.Queries.GetAllUserAbility
{
    public class GetAllUserAbilityQuery : IRequest<ManyUserAbilityResponse>
    {
        public string? UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllUserAbilityQueryHandler : IRequestHandler<GetAllUserAbilityQuery, ManyUserAbilityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAbilityRepository _userAbilityRepository;
        private readonly IAbilityRepository _abilityRepository;

        public GetAllUserAbilityQueryHandler(IMapper mapper, IUserAbilityRepository userAbilityRepository, IAbilityRepository abilityRepository)
        {
            _mapper = mapper;
            _userAbilityRepository = userAbilityRepository;
            _abilityRepository = abilityRepository;
        }

        public async Task<ManyUserAbilityResponse> Handle(GetAllUserAbilityQuery request, CancellationToken cancellationToken)
        {
            var result = await _userAbilityRepository.GetAllOrderAndPaginateAsync(x => x.UserId == request.UserId,
                x => x.CreatedAt,
                false,
                request.PageNumber,
                request.PageSize,
                x => x.Ability);



            if (result.Result == null)
            {
                throw new ApiException("No user ability were found", StatusCodes.Status404NotFound);

            }
            ManyUserAbilityResponse response = new();
            response.TotalCount = result.TotalCount;
            response.TotalPages = result.TotalPages;
            response.HasPrevious = result.HasPrevious;
            response.HasNext = result.HasNext;
            response.Succeeded = true;
            response.Data = _mapper.Map<List<UserAbilityResponse>>(result.Result);
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
