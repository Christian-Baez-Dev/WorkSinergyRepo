using AutoMapper;
using MediatR;
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
            var entity = _mapper.Map<Ability>(request);
            await _abilityRepository.CreateAsync(entity);
            return new Response<int>();
        }
    }
}
