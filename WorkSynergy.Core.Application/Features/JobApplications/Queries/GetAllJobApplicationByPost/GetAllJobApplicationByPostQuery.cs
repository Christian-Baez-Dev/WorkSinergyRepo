using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.JobApplication;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;

namespace WorkSynergy.Core.Application.Features.JobApplications.Queries.GetAllJobApplicationByPost
{
    public class GetAllJobApplicationByPostQuery : IRequest<ManyJobApplicationResponse>
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class GetAllJobApplicationByPostQueryHandler : IRequestHandler<GetAllJobApplicationByPostQuery, ManyJobApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetAllJobApplicationByPostQueryHandler(IMapper mapper, IJobApplicationRepository jobApplicationRepository)
        {
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<ManyJobApplicationResponse> Handle(GetAllJobApplicationByPostQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobApplicationRepository.GetAllOrderAndPaginateAsync(x => x.PostId == request.Id && x.Status == nameof(AsynchronousStatus.Waiting),
            null, false, request.PageNumber, request.PageSize);


            if (result.Result == null || result.TotalCount == 0)
                throw new ApiException("No job applications were found based on this provided identificator", StatusCodes.Status404NotFound);

            ManyJobApplicationResponse response = new();
            response.TotalCount = result.TotalCount;
            response.PageNumber = request.PageNumber;
            response.TotalPages = result.TotalPages;
            response.HasPrevious = result.HasPrevious;
            response.HasNext = result.HasNext;
            response.Data = _mapper.Map<List<JobApplicationResponse>>(result.Result);
            response.StatusCode = StatusCodes.Status200OK;
            response.Succeeded = true;

            return response;

        }
    }
}
