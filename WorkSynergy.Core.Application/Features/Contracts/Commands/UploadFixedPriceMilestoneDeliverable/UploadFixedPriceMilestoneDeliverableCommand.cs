using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Enums.Upload;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Helpers;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.Currencies.Commands.UploadFixedPriceMilestoneDeliverable
{

    public class UploadFixedPriceMilestoneDeliverableCommand : IRequest<Response<int>>
    {
        public int ContractId { get; set; }
        public int MilestoneId { get; set; }

        public IFormFile Deliverable { get; set; }
    }
    
    public class UploadFixedPriceMilestoneDeliverableCommandHandler : IRequestHandler<UploadFixedPriceMilestoneDeliverableCommand, Response<int>>
    {
        private readonly IFixedPriceMilestoneRepository _fixedPriceMilestoneRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public UploadFixedPriceMilestoneDeliverableCommandHandler(IFixedPriceMilestoneRepository fixedPriceMilestoneRepository, IContractRepository contractRepository, IMapper mapper)
        {
            _fixedPriceMilestoneRepository = fixedPriceMilestoneRepository;
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UploadFixedPriceMilestoneDeliverableCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.GetByIdIncludeAsync(request.ContractId, x => x.FixedPriceMilestones);
            if (contract.FixedPriceMilestones == null || !contract.FixedPriceMilestones.Any())
            {
                throw new ApiException("Invalid contract provided", StatusCodes.Status400BadRequest);
            }
            if (contract.Id == 0 || contract.ContractOptionId == (int)ContractOptions.PerHour)
            {
                throw new ApiException("Invalid contract provided", StatusCodes.Status400BadRequest);
            }
            var milestone = contract.FixedPriceMilestones.FirstOrDefault(x => x.Id == request.MilestoneId);
            if (milestone != null)
            {
                throw new ApiException("Invalid milestone provided", StatusCodes.Status400BadRequest);
            }
            var path = UploadHelper.UploadFile(request.Deliverable, contract.Id.ToString(), nameof(UploadTypes.Deliverables), nameof(UploadEntities.FixedPriceDeliverable));
            if (string.IsNullOrEmpty(path))
            {
                throw new ApiException("Error while saving the deliverable", StatusCodes.Status500InternalServerError);
            }
            milestone.IsCompleted = true;
            milestone.FilePath = path;
            var result = await _contractRepository.UpdateAsync(contract, contract.Id);
            var response = new Response<int>();

            response.Succeeded = true;
            response.Data = milestone.Id;
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }
}
