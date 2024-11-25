using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Abilities.Queries.GetAllAbilities
{
    public class GetAllCurrencyQuery : IRequest<ManyCurrencyResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllCurrencyQueryHandler : IRequestHandler<GetAllCurrencyQuery, ManyCurrencyResponse>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public GetAllCurrencyQueryHandler(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<ManyCurrencyResponse> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
        {
            var result = await _currencyRepository.GetAllOrderAndPaginateAsync(null, null, false, request.PageNumber, request.PageSize);
            ManyCurrencyResponse response = new();
            if (result.Result == null || result.Result.Count == 0) 
            {
                throw new ApiException("No currencies were found", StatusCodes.Status404NotFound);
            }
            response.Data = _mapper.Map<List<CurrencyResponse>>(result.Result);
            response.TotalPages = result.TotalPages;
            response.HasPrevious = result.HasPrevious;
            response.HasNext = result.HasNext;
            response.PageNumber = request.PageNumber;
            response.TotalCount = result.TotalCount;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
