using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Infrastucture.Persistence.Contexts;
using WorkSynergy.Infrastucture.Persistence.Repositories;

namespace WorkSynergy.Infrastucture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("RealEstateDB"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                });
            }
            #endregion

            #region Repositories
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IPostAbilitiesRepository, PostAbilitiesRepository>();
            services.AddTransient<IAbilityRepository, AbilityRepository>();
            services.AddTransient<IUserAbilitiesRepository, UserAbilitiesRepository>();
            services.AddTransient<IFreelancerJobOffersRepository, FreelancerJobOffersRepository>();
            services.AddTransient<IJobRatingRepository, JobRatingRepository>();
            services.AddTransient<IJobOfferRepository, JobOfferRepository>();
            services.AddTransient<IJobApplicationRepository, JobApplicationRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostTagsRepository, PostTagsRepository>();
            #endregion
        }

    }
}
