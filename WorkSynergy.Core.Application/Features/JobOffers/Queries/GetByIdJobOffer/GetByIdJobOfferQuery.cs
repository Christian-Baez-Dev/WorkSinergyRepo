using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.JobOffer;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.JobOffers.Queries.GetByIdJobOffer
{
    public class GetByIdJobOfferQuery : IRequest<Response<JobOfferResponse>>
    {
        public int Id { get; set; }
    }

    public class GetByIdJobOfferQueryHandler : IRequestHandler<GetByIdJobOfferQuery, Response<JobOfferResponse>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public GetByIdJobOfferQueryHandler(IJobOfferRepository jobOfferRepository, IMapper mapper
            )
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public async Task<Response<JobOfferResponse>> Handle(GetByIdJobOfferQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobOfferRepository.GetByIdIncludeAsync(request.Id, x => x.Currency, x => x.ContractOption, x => x.Post);
            if (result == null) 
            {
                throw new ApiException("No ability were found", StatusCodes.Status404NotFound);
            }
            Response<JobOfferResponse> response = new();
            response.Succeeded = true;
            response.Data = _mapper.Map<JobOfferResponse>(result);
            response.StatusCode = StatusCodes.Status200OK;
            return response;
        }
    }

}
