using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.UserAbilities.Commands
{
    public class DeleteUserAbilityCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteUserAbilityCommandCommandHandler : IRequestHandler<DeleteUserAbilityCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAbilityRepository _userAbilityRepository;

        public DeleteUserAbilityCommandCommandHandler(IMapper mapper, IUserAbilityRepository userAbilityRepository)
        {
            _mapper = mapper;
            _userAbilityRepository = userAbilityRepository;
        }

        public async Task<Response<int>> Handle(DeleteUserAbilityCommand request, CancellationToken cancellationToken)
        {
            var userAbility = await _userAbilityRepository.GetByIdAsync(request.Id);
            await _userAbilityRepository.DeleteAsync(userAbility);

            Response<int> response = new();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;

            return response;
        }
    }

}
