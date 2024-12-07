using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.DTOs.Entities.JobApplication;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Interfaces.Services;

namespace WorkSynergy.Core.Application.Features.JobApplications.Queries.GetAllJobApplicationByUser
{
    public class GetAllJobApplicationByUserQuery : IRequest<ManyJobApplicationResponse>
    {
        public string Id { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class GetAllJobApplicationByUserQueryHandler : IRequestHandler<GetAllJobApplicationByUserQuery, ManyJobApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public GetAllJobApplicationByUserQueryHandler(IMapper mapper, IJobApplicationRepository jobApplicationRepository)
        {
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<ManyJobApplicationResponse> Handle(GetAllJobApplicationByUserQuery request, CancellationToken cancellationToken)
        {

            var result = await _jobApplicationRepository.GetAllOrderAndPaginateAsync(x => x.ApplicantId == request.Id && x.Status == nameof(AsynchronousStatus.Waiting), null, false, request.PageNumber, request.PageSize, x => x.Post);

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
