﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Contracts;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Exceptions;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Application.Wrappers;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Features.JobOffers.Commands.CreateJobOfferCommand
{
    public class CreateJobOfferCommand : IRequest<Response<int>>
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; } //fecha de inicio
        public DateTime EndDate { get; set; }  // fecha de cierre
        public double HourlyRate { get; set; } // promedio de money por horas
        public string ClientUserId { get; set; }
        public string FreelancerId { get; set; }
        public int TotalHours { get; set; }
        public int PostId { get; set; }
        public int CurrencyId { get; set; }
        public int ContractOptionId { get; set; }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Response<int>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {

            switch (request.ContractOptionId)
            {
                case (int)ContractOptions.FixedPrice:
                    if (request.TotalHours != 0)
                    {
                        throw new ApiException("Total hours must be 0 for fixed price", StatusCodes.Status400BadRequest);
                    }
                    break;
                case (int)ContractOptions.PerHour:
                    if (request.TotalHours == 0)
                    {
                        throw new ApiException("Total hours must be more than 0", StatusCodes.Status400BadRequest);
                    }
                    //if (TimeSpan.FromHours(request.TotalHours).TotalMilliseconds / TimeSpan.FromHours(8).TotalMilliseconds > (request.EndDate - request.StartDate).TotalDays)
                    //{
                    //    throw new ApiException("Invalid total hours provided. The hours cannot exceed the 8 laborable hours", StatusCodes.Status400BadRequest);

                    //}
                    //if (TimeSpan.FromHours(request.TotalHours).TotalMilliseconds / TimeSpan.FromHours(8).TotalMilliseconds > (request.EndDate.AddDays(-7) - request.StartDate).TotalDays)
                    //{
                    //    throw new ApiException("Invalid end date provided. The end date has to be at least 7 days extra than the maximum of laborable days", StatusCodes.Status400BadRequest);

                    //}
                    break;
                default:
                    throw new ApiException("Invalid contract option provided", StatusCodes.Status500InternalServerError);
            }


            var response = new Response<int>();
            var entity = _mapper.Map<JobOffer>(request);

            if ((entity.StartDate.Date - DateTime.Now.Date).Days < 7)
                entity.ExpirationDate = DateTime.Now.AddDays((entity.StartDate.Date - DateTime.Now.Date).Days).Date.AddDays(1).AddSeconds(-1);
            else
                entity.ExpirationDate = DateTime.Now.AddDays(7).Date.AddDays(1).AddSeconds(-1);

            entity.Status = nameof(AsynchronousStatus.Waiting);
            await _jobOfferRepository.CreateAsync(entity);
            if (entity.Id == 0)
            {
                throw new ApiException("Error while creating the job offer", StatusCodes.Status500InternalServerError);
            }
            response.Data = entity.Id;
            response.Succeeded = true;
            response.StatusCode = StatusCodes.Status201Created;
            return response;
        }
    }
}
