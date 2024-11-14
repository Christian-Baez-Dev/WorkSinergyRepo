using AutoMapper;
using MediatR;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Commands.DeleteAbility
{
    public class DeleteAbilityCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteAbilityCommandHandler : IRequestHandler<DeleteAbilityCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAbilityRepository _abilityRepository;

        public DeleteAbilityCommandHandler(IMapper mapper, IAbilityRepository abilityRepository)
        {
            _mapper = mapper;
            _abilityRepository = abilityRepository;
        }

        public async Task<Response<int>> Handle(DeleteAbilityCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            response.Succeeded = true;
            var post = await _abilityRepository.GetByIdAsync(request.Id);
            await _abilityRepository.DeleteAsync(post);
            return response;
        }
    }
}
