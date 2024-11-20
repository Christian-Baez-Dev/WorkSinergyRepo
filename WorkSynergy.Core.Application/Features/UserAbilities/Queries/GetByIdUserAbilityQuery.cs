using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.UserAbility;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.UserAbilities.Queries
{
    public class GetByIdUserAbilityQuery : IRequest<Response<UserAbilityResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdUserAbilityQueryHandler : IRequestHandler<GetByIdUserAbilityQuery, Response<UserAbilityResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAbilityRepository _userAbilityRepository;
        private readonly IAbilityRepository _abilityRepository;

        public GetByIdUserAbilityQueryHandler(IMapper mapper, IUserAbilityRepository userAbilityRepository, IAbilityRepository abilityRepository)
        {
            _mapper = mapper;
            _userAbilityRepository = userAbilityRepository;
            _abilityRepository = abilityRepository;
        }

        public async Task<Response<UserAbilityResponse>> Handle(GetByIdUserAbilityQuery request, CancellationToken cancellationToken)
        {
            var userAbility = await _userAbilityRepository.GetByIdIncludeAsync(request.Id, x => x.Ability);
            if(userAbility == null)
            {
                throw new ApiException("No user ability were found", StatusCodes.Status404NotFound);

            }
            var result = _mapper.Map<UserAbilityResponse>(userAbility);
            Response<UserAbilityResponse> response = new();
            response.Succeeded = true;
            response.Data = result;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }


}
