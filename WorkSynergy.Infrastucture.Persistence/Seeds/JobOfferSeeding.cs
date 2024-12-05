﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Seeds
{
    public static class JobOfferSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.JobOffers.Count() == 0)
            {

                var offers = new List<JobOffer>
                {
                    new JobOffer 
                    {
                        FreelancerId = "freelancer1-id",
                        ClientUserId = "client1-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 1,
                        ContractOptionId = 1,
                        CurrencyId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 10000,
                        StartDate = DateTime.Now.AddDays(8),
                        EndDate = DateTime.Now.AddDays(38),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer2-id",
                        ClientUserId = "client1-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 2,
                        ContractOptionId = 2,
                        CurrencyId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 1044560,
                        StartDate = DateTime.Now.AddDays(8),
                        EndDate = DateTime.Now.AddDays(20),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer4-id",
                        ClientUserId = "client2-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 3,
                        ContractOptionId = 1,
                        CurrencyId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 3333333,
                        StartDate = DateTime.Now.AddDays(9),
                        EndDate = DateTime.Now.AddDays(15),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer3-id",
                        ClientUserId = "client2-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 4,
                        ContractOptionId = 2,
                        CurrencyId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 100,
                        StartDate = DateTime.Now.AddDays(7),
                        EndDate = DateTime.Now.AddDays(45),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer3-id",
                        ClientUserId = "client3-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 5,
                        ContractOptionId = 1,
                        CurrencyId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 123123,
                        StartDate = DateTime.Now.AddDays(7),
                        EndDate = DateTime.Now.AddDays(12),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer1-id",
                        ClientUserId = "client3-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 6,
                        ContractOptionId = 2,
                        CurrencyId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 12123123,
                        StartDate = DateTime.Now.AddDays(8),
                        EndDate = DateTime.Now.AddDays(68),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer2-id",
                        ClientUserId = "client4-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 7,
                        ContractOptionId = 1,
                        CurrencyId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 105500,
                        StartDate = DateTime.Now.AddDays(8),
                        EndDate = DateTime.Now.AddDays(11),

                    },
                    new JobOffer
                    {
                        FreelancerId = "freelancer3-id",
                        ClientUserId = "client4-id",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        PostId = 8,
                        ContractOptionId = 2,
                        CurrencyId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                        Description = "Te queremos contratar locotron",
                        Title = "Vamo a trabaja",
                        HourlyRate = 1000000,
                        StartDate = DateTime.Now.AddDays(8),
                        EndDate = DateTime.Now.AddDays(200),

                    },

                };
                try
                {

                    context.JobOffers.AddRange(offers);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
