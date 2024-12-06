using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Interfaces.Services;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Contracts.Queries.GetAllContract
{
    public class GetAllContractQuery : IRequest<ManyContractResponse>
    {
        public string Role { get; set; }
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllContractQueryHandler : IRequestHandler<GetAllContractQuery, ManyContractResponse>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public GetAllContractQueryHandler(IContractRepository contractRepository, IAccountService accountService, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<ManyContractResponse> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
        {
            var result = await _contractRepository.GetAllOrderAndPaginateAsync(x => x.FreelancerId == request.UserId || x.CreatorUserId == request.UserId, null, false, request.PageNumber, request.PageSize, x => x.ContractOption, x => x.Currency, x => x.FixedPriceMilestones, x => x.HourlyMilestones);
            var contracts = _mapper.Map<List<ContractResponse>>(result.Result);
            foreach (var contract in contracts) 
            {
                switch (request.Role)
                {
                    case nameof(UserRoles.Client):
                        var freelancer = await _accountService.GetByIdAsyncDTO(contract.FreelancerId);
                        contract.Freelancer = freelancer.Data;
                        break;
                    case nameof(UserRoles.Freelancer):
                        var client = await _accountService.GetByIdAsyncDTO(contract.CreatorUserId);
                        contract.CreatorUser = client.Data;
                        break;
                    default:
                        throw new ApiException("Invalid role provided", StatusCodes.Status400BadRequest);
                }
            }
            ManyContractResponse response = new();
            response.Data = contracts;
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
