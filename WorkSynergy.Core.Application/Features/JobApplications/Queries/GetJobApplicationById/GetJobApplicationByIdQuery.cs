using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WorkSynergy.Core.Application.DTOs.Entities.JobApplication;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Features.JobApplications.Queries.GetAllJobApplicationByPost
{
    public class GetJobApplicationByIdQuery : IRequest<Response<JobApplicationResponse>>
    {
        public int Id { get; set; }

    }

    public class GetJobApplicationByIdQueryHandler : IRequestHandler<GetJobApplicationByIdQuery, Response<JobApplicationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IPostRepository _postRepository;

        public GetJobApplicationByIdQueryHandler(IMapper mapper, IJobApplicationRepository jobApplicationRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
            _postRepository = postRepository;
        }

        public async Task<Response<JobApplicationResponse>> Handle(GetJobApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobApplicationRepository.FindAsync(x => x.Status == nameof(AsynchronousStatus.Waiting));
            if (result == null)
            {
                throw new ApiException("No job application was found", StatusCodes.Status404NotFound);
            }
            result.Post = await _postRepository.GetByIdIncludeAsync(result.PostId, x => x.Currency, x => x.Abilities, x => x.ContractOption, x => x.Tags);
            Response<JobApplicationResponse> response = new();
            response.Data = _mapper.Map<JobApplicationResponse>(result);
            response.StatusCode = StatusCodes.Status200OK;
            response.Succeeded = true;

            return response;

        }
    }
}
