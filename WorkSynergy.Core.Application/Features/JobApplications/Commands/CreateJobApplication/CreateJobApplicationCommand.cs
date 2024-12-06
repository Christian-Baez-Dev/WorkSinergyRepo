using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.JobApplications.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommand : IRequest<Response<int>>
    {
        public string ApplicantId { get; set; }
        public int PostId { get; set; }
        public string Description { get; set; }

    }

    public class CreateJobApplicantCommandHandler : IRequestHandler<CreateJobApplicationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public CreateJobApplicantCommandHandler(IMapper mapper, IJobApplicationRepository jobApplicationRepository)
        {
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<Response<int>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApplication = _mapper.Map<JobApplication>(request);
            jobApplication.Status = nameof(AsynchronousStatus.Waiting);
            var jobApplicationWithSameUser = await _jobApplicationRepository.FindAsync(x => x.ApplicantId == request.ApplicantId && x.PostId == request.PostId);
            if (jobApplicationWithSameUser != null)
            {
                throw new ApiException("You cannot apply more than once to a job", StatusCodes.Status400BadRequest);
            }
            var result = await _jobApplicationRepository.CreateAsync(jobApplication);
            if (result == null)
            {
                throw new ApiException("Error while creating the job application", StatusCodes.Status500InternalServerError);
            }
            Response<int> response = new();
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Data = result.Id;
            return response;
        }
    }
}
