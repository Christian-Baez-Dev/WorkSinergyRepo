using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Abilities.Commands.UpdateAbility
{
    public class UpdateCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        public UpdateCurrencyCommandHandler(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<Response<int>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var currency = _mapper.Map<Currency>(request);
            if(await _currencyRepository.GetByIdAsync(request.Id) == null)
            {
                throw new ApiException("Currency not found", StatusCodes.Status404NotFound);
            }
            var result = await _currencyRepository.UpdateAsync(currency, request.Id);
            if(result == null)
            {
                throw new ApiException("Error while creating Currency", StatusCodes.Status500InternalServerError);
            }
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
