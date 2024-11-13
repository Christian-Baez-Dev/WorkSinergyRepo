using AutoMapper;
using MediatR;
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
        private readonly IAbilityRepository _tagRepository;

        public UpdateAbilityCommandHandler(IMapper mapper, IAbilityRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<Response<int>> Handle(UpdateAbilityCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            response.Succeeded = true;
            var result = _tagRepository.UpdateAsync(_mapper.Map<Ability>(request), request.Id);
            return response;
        }
    }
}
