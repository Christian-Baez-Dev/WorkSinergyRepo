using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Commands.DeleteAbility
{
    public class DeletCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletCurrencyCommandHandler : IRequestHandler<DeletCurrencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;

        public DeletCurrencyCommandHandler(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<Response<int>> Handle(DeletCurrencyCommand request, CancellationToken cancellationToken)
        {
            Response<int> response = new();
            var currency = await _currencyRepository.GetByIdAsync(request.Id);
            if(currency == null)
            {
                throw new ApiException("Currency not found", StatusCodes.Status404NotFound);
            }
            await _currencyRepository.DeleteAsync(currency);
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }
}
