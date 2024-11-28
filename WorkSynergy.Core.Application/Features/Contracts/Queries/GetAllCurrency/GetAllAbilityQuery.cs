using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Currencies.Queries.GetAllCurrency
{
    public class GetAllContractQuery : IRequest<ManyContractResponse>
    {
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllContractQueryHandler : IRequestHandler<GetAllContractQuery, ManyContractResponse>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetAllContractQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<ManyContractResponse> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
        {
            var result = await _contractRepository.GetAllOrderAndPaginateAsync(x => x.FreelancerId == request.UserId || x.CreatorUserId == request.UserId, null, false, request.PageNumber, request.PageSize, x => x.ContractOption, x => x.Currency, x => x.FixedPriceMilestones, x => x.HourlyMilestones);
            ManyContractResponse response = new();
            if (result.Result == null || result.Result.Count == 0)
            {
                throw new ApiException("No contracts were found", StatusCodes.Status404NotFound);
            }
            response.Data = _mapper.Map<List<ContractResponse>>(result.Result);
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
