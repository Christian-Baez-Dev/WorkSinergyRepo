﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.JobOffer;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.JobOffers.Queries.GetAllJobOfferByFreelancer
{
    public class GetAllJobOfferByFreelancerQuery : IRequest<ManyJobOffersResponse>
    {
        public string Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllJobOfferByFreelancerQueryHandler : IRequestHandler<GetAllJobOfferByFreelancerQuery, ManyJobOffersResponse>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public GetAllJobOfferByFreelancerQueryHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public async Task<ManyJobOffersResponse> Handle(GetAllJobOfferByFreelancerQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobOfferRepository.GetAllOrderAndPaginateAsync(x => x.FreelancerId == request.Id, null, false, request.PageNumber, request.PageSize, x => x.ContractOption, x => x.Currency, x => x.Post);
            ManyJobOffersResponse response = new();
            if (result.Result == null || result.Result.Count == 0)
            {
                throw new ApiException("No abilities were found", StatusCodes.Status404NotFound);
            }
            response.Data = _mapper.Map<List<JobOfferResponse>>(result.Result);
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
