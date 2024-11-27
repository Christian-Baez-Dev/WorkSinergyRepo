using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Currencies.Commands.CreateCurrency
{
    /// <summary>
    /// Continuar
    /// </summary>
    public class UploadDeliverableCommand : IRequest<Response<int>>
    {
        public int? HourMade { get; set; }
        public int ContractId { get; set; }
        public int ContractOption {  get; set; }
        public IFormFile Deliverable { get; set; }
    }
    
    public class UploadDeliverableCommandHandler : IRequestHandler<UploadDeliverableCommand, Response<int>>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public UploadDeliverableCommandHandler(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UploadDeliverableCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<int>();
            var entity = _mapper.Map<Currency>(request);
            await _currencyRepository.CreateAsync(entity);
            if(entity.Id == 0)
            {
                throw new ApiException("Error while creating Currency", StatusCodes.Status500InternalServerError);
            }
            response.Data = entity.Id;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
    }
}
