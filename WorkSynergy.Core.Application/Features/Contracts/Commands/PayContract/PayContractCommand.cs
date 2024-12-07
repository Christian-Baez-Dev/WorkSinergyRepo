using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Enums.Upload;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Features.Currencies.Commands.UploadFixedPriceMilestoneDeliverable;
using WorkSynergy.Core.Application.Helpers;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.Contracts.Commands.PayContract
{
    public class PayContractCommand : IRequest<Response<int>>
    {
        public int ContractId { get; set; }
        public double Amount { get; set; }
    }

    public class PayContractCommandHandler : IRequestHandler<PayContractCommand, Response<int>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public PayContractCommandHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(PayContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetByIdIncludeAsync(request.ContractId, x => x.FixedPriceMilestones);
            if (contract == null)
            {
                throw new ApiException("Invalid contract provided", StatusCodes.Status400BadRequest);
            }
            if (contract.CurrentPayment + request.Amount > contract.TotalPayment)
            {
                contract.CurrentPayment = request.Amount - (request.Amount - contract.TotalPayment);
            }
            else
            {
                contract.CurrentPayment += request.Amount;
            }
            var result = await _contractRepository.UpdateAsync(contract, contract.Id);
            var response = new Response<int>();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }
}
