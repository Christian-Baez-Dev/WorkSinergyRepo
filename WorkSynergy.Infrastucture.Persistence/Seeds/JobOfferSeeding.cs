using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

public static class JobOfferSeeding
{
    public static async Task SeedAsync(ApplicationContext context)
    {
        if (!context.JobOffers.Any())
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
                    TotalHours = 300 // 12 horas diarias * 30 días
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
                    TotalHours = 96 // 12 horas diarias * 12 días
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
                    TotalHours = 44 // 12 horas diarias * 6 días
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
                    TotalHours = 250 // 12 horas diarias * 38 días
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
                    TotalHours = 24 // 12 horas diarias * 5 días
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
                    TotalHours = 400 // 12 horas diarias * 60 días
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
                    TotalHours = 26 // 12 horas diarias * 3 días
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
                    TotalHours = 2300 // 12 horas diarias * 200 días
                },
            };

            try
            {
                context.JobOffers.AddRange(offers);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al hacer el seeding: {ex.Message}");
            }
        }
    }
}
