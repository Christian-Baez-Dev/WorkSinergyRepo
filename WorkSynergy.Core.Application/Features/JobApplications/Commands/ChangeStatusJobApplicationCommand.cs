using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.JobApplications.Commands
{
    public class ChangeStatusJobApplicationCommand : IRequest<Response<int>>
    {
        [SwaggerParameter(Description = "This is the id of the job application that you want to change its status")]
        public int JobApplicationId { get; set; }
        [SwaggerParameter(Description = "This is the status to apply. you can change it to \"Accepted\" or \"Declined\" but you cannot change it to \"Waiting\"")]
        public string StatusName { get; set; }
    }

    public class ChangeStatusJobApplicationCommandHandler : IRequestHandler<ChangeStatusJobApplicationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public ChangeStatusJobApplicationCommandHandler(IMapper mapper, IJobApplicationRepository jobApplicationRepository)
        {
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<Response<int>> Handle(ChangeStatusJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApplication = await _jobApplicationRepository.GetByIdAsync(request.JobApplicationId);
            if (jobApplication == null) throw new ApiException("No Job Application were found, please enter a valid identificator", StatusCodes.Status404NotFound);
            if (!Enum.IsDefined(typeof(JobApplicationStatusEnum), request.StatusName) || request.StatusName.Equals(nameof(JobApplicationStatusEnum.Waiting))) throw new ApiException("Wrong job application status provided", StatusCodes.Status400BadRequest);

            jobApplication.Status = request.StatusName;
            var result = await _jobApplicationRepository.UpdateAsync(jobApplication, jobApplication.Id);
            if(result == null) throw new ApiException("Error while updating the job application status", StatusCodes.Status500InternalServerError);
            Response<int> response = new();
            response.StatusCode = StatusCodes.Status204NoContent;
            response.Succeeded = true;
            return response;
        }
    }
}
