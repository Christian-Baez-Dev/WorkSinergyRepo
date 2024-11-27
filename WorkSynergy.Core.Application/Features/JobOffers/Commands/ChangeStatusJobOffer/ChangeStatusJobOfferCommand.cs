using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.JobOffers.Commands.CreateJobOfferCommand
{
    public class ChangeStatusJobOfferCommand : IRequest<Response<int>>
    {
        public string Status { get; set; }
        public int JobOfferId { get; set; }

    }

    public class ChangeStatusJobOfferCommandHandler : IRequestHandler<ChangeStatusJobOfferCommand, Response<int>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ChangeStatusJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IContractRepository contractRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ChangeStatusJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOffer = await _jobOfferRepository.FindAsync(x => x.Id == request.JobOfferId && x.Status.Equals(nameof(AsynchronousStatus.Waiting)));
            if (jobOffer == null || !jobOffer.Status.Equals(nameof(AsynchronousStatus.Waiting)))
            {
                throw new ApiException("Invalid job offer provided", StatusCodes.Status400BadRequest);
            }
            Response<int> response = new();
            switch (request.Status)
            {
                case nameof(AsynchronousStatus.Accepted):
                    response = await AcceptJobOffer(jobOffer);
                    break;
                case nameof(AsynchronousStatus.Declined):
                    response = await DeclineJobOffer(jobOffer);
                    break;
                default:
                    throw new ApiException("Invalid status provided", StatusCodes.Status500InternalServerError);
            }

            return response;
        }
        private async Task<Response<int>> AcceptJobOffer(JobOffer jobOffer)
        {
            Contract contract = new()
            {
                Title = jobOffer.Title,
                Description = jobOffer.Description,
                ContractOptionId = jobOffer.ContractOptionId,
                FreelancerId = jobOffer.FreelancerId,
                CreatorUserId = jobOffer.ClientUserId,
                CurrencyId = jobOffer.CurrencyId,
                StartDate = jobOffer.StartDate,
                EndDate = jobOffer.EndDate,
            };
            var transaction = _contractRepository.BeginTransaction();
            try
            {
                jobOffer.Status = nameof(AsynchronousStatus.Accepted);
                var jobOfferUpdateResult = await _jobOfferRepository.UpdateAsync(jobOffer, jobOffer.Id);
                if (jobOfferUpdateResult == null)
                {
                    throw new ApiException("Error while updating the status of the job offer", StatusCodes.Status500InternalServerError);
                }

                switch (jobOffer.ContractOptionId)
                {
                    case (int)ContractOptions.FixedPrice:
                        FixedPriceMilestone fixedMilestone = new()
                        {
                            EndDate = jobOffer.EndDate,
                            Name = "First milestone",
                            StartDate = jobOffer.StartDate
                        };
                        contract.FixedPriceMilestones = new List<FixedPriceMilestone>() { fixedMilestone };
                        break;
                    case (int)ContractOptions.PerHour:
                        HourlyMilestone hourlyMilestone = new()
                        {
                            TotalHours = 100,

                        };
                        contract.HourlyMilestones = new List<HourlyMilestone>() { hourlyMilestone };
                        break;
                    default:
                        throw new ApiException("Invalid contract option provided", StatusCodes.Status500InternalServerError);
                }
                var createContractResult = await _contractRepository.CreateAsync(contract);
                if (createContractResult == null)
                {
                    throw new ApiException("Error while creating the contract", StatusCodes.Status500InternalServerError);

                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                throw ex;

            }
            var response = new Response<int>();
            response.Data = contract.Id;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
        private async Task<Response<int>> DeclineJobOffer(JobOffer jobOffer)
        {
            jobOffer.Status = nameof(AsynchronousStatus.Declined);
            var jobOfferUpdateResult = await _jobOfferRepository.UpdateAsync(jobOffer, jobOffer.Id);
            if (jobOfferUpdateResult == null)
            {
                throw new ApiException("Error while updating the status of the job offer", StatusCodes.Status500InternalServerError);
            }
            var response = new Response<int>();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status204NoContent;
            return response;
        }
    }
}
