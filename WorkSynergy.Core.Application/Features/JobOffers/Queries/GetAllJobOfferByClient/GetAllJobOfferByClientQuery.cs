using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.JobOffer;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;

namespace WorkSynergy.Core.Application.Features.JobOffers.Queries.GetAllJobOfferByClient
{
    public class GetAllJobOfferByClientQuery : IRequest<ManyJobOffersResponse>
    {
        public string Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }

    public class GetAllJobOfferByClientQueryHandler : IRequestHandler<GetAllJobOfferByClientQuery, ManyJobOffersResponse>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllJobOfferByClientQueryHandler(IJobOfferRepository jobOfferRepository, IPostRepository postRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<ManyJobOffersResponse> Handle(GetAllJobOfferByClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobOfferRepository.GetAllOrderAndPaginateAsync(x => x.ClientUserId == request.Id && x.Status == nameof(AsynchronousStatus.Waiting), null, false, request.PageNumber, request.PageSize, x => x.ContractOption, x => x.Currency);
            ManyJobOffersResponse response = new();
            foreach (var item in result.Result)
            {
                item.Post = await _postRepository.GetByIdIncludeAsync(item.PostId, x => x.Tags, x => x.Abilities);
                if (item.Post == null)
                {
                    throw new ApiException("Invalid post", StatusCodes.Status500InternalServerError);
                }
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
