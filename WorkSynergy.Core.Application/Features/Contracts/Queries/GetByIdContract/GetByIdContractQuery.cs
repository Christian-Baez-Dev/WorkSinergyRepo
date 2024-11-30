using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Contracts.Queries.GetByIdContract
{
    public class GetByIdContractQuery : IRequest<Response<ContractResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdContractQueryHandler : IRequestHandler<GetByIdContractQuery, Response<ContractResponse>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetByIdContractQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<Response<ContractResponse>> Handle(GetByIdContractQuery request, CancellationToken cancellationToken)
        {
            var result = await _contractRepository.GetByIdIncludeAsync(request.Id, x => x.ContractOption, x => x.Currency, x => x.FixedPriceMilestones, x => x.HourlyMilestones);
            if (result == null)
            {
                throw new ApiException("No contract were found", StatusCodes.Status404NotFound);
            }
            Response<ContractResponse> response = new();
            response.Data = _mapper.Map<ContractResponse>(result);
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
