using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.UserAbilities.Commands
{
    public class CreateUserAbilityCommand : IRequest<Response<int>>
    {
        public string UserId { get; set; }
        public int AbilityId { get; set; }
    }

    public class CreateUserAbilityCommandHandler : IRequestHandler<CreateUserAbilityCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserAbilityRepository _userAbilityRepository;

        public CreateUserAbilityCommandHandler(IMapper mapper, IUserAbilityRepository userAbilityRepository)
        {
            _mapper = mapper;
            _userAbilityRepository = userAbilityRepository;
        }

        public async Task<Response<int>> Handle(CreateUserAbilityCommand request, CancellationToken cancellationToken)
        {
            var userAbility = _mapper.Map<UserAbility>(request);
            var result = await _userAbilityRepository.CreateAsync(userAbility);
            if (result.Id == 0)
            {
                throw new ApiException("Error while creating the user ability", StatusCodes.Status500InternalServerError);

            }
            Response<int> response = new();
            response.Succeeded = true;
            response.Data = result.Id;
            response.StatusCode = StatusCodes.Status201Created;

            return response;
        }
    }

}
