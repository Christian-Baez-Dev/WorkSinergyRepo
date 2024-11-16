using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
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
            var ability = await _abilityRepository.GetByIdAsync(request.Id);
            if(ability == null)
            {
                throw new ApiException("Ability not found", StatusCodes.Status404NotFound);
            }
            await _abilityRepository.DeleteAsync(ability);
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }
}
