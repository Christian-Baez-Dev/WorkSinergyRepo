using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Abilities.Commands.CreateAbilitiesCommand
{
    public class CreateAbilityCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    
    public class CreateAbilityCommandHandler : IRequestHandler<CreateAbilityCommand, Response<int>>
    {
        private readonly IAbilityRepository _abilityRepository;
        private readonly IMapper _mapper;

        public CreateAbilityCommandHandler(IAbilityRepository abilityRepository, IMapper mapper)
        {
            _abilityRepository = abilityRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAbilityCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<int>();
            var entity = _mapper.Map<Ability>(request);
            await _abilityRepository.CreateAsync(entity);
            if(entity.Id == 0)
            {
                throw new ApiException("Error while creating Ability", StatusCodes.Status500InternalServerError);
            }
            response.Data = entity.Id;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
    }
}
