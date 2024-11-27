using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Currencies.Queries.GetByIdCurrency
{
    //public class GetByIdCurrencyQuery : IRequest<Response<CurrencyResponse>>
    //{
    //    public int Id { get; set; }
    //}

    //public class GetByIdCurrencyQueryHandler : IRequestHandler<GetByIdCurrencyQuery, Response<CurrencyResponse>>
    //{
    //    private readonly ICurrencyRepository _currencyRepository;
    //    private readonly IMapper _mapper;

    //    public GetByIdCurrencyQueryHandler(ICurrencyRepository currencyRepository, IMapper mapper)
    //    {
    //        _currencyRepository = currencyRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<Response<CurrencyResponse>> Handle(GetByIdCurrencyQuery request, CancellationToken cancellationToken)
    //    {
    //        var result = await _currencyRepository.GetByIdAsync(request.Id);
    //        if (result == null) 
    //        {
    //            throw new ApiException("No currency were found", StatusCodes.Status404NotFound);
    //        }
    //        Response<CurrencyResponse> response = new();
    //        response.Succeeded = true;
    //        response.Data = _mapper.Map<CurrencyResponse>(result);
    //        response.StatusCode = StatusCodes.Status200OK;
    //        return response;
    //    }
    //}

}
