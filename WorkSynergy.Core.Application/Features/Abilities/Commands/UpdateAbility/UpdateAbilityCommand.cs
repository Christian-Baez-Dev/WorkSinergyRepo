using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Abilities.Commands.UpdateAbility
{
    public class UpdateAbilityCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class UpdateAbilityCommandHandler : IRequestHandler<UpdateAbilityCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;

        public UpdateAbilityCommandHandler(IMapper mapper, IAbilityRepository abilityRepository)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
        }

        public async Task<Response<int>> Handle(UpdateAbilityCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var ability = _mapper.Map<Ability>(request);
            if(await _abilityRepository.GetByIdAsync(request.Id) == null)
            {
                throw new ApiException("Ability not found", StatusCodes.Status404NotFound);
            }
            var result = await _abilityRepository.UpdateAsync(ability, request.Id);
            if(result == null)
            {
                throw new ApiException("Error while creating ability", StatusCodes.Status500InternalServerError);
            }
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
