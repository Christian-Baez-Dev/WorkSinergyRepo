
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkSynergy.Core.Application;
using WorkSynergy.Infrastucture.Identity;
using WorkSynergy.Infrastucture.Identity.Models;
using WorkSynergy.Infrastucture.Identity.Seeds;
using WorkSynergy.Infrastucture.Persistence;
using WorkSynergy.Infrastucture.Persistence.Contexts;
using WorkSynergy.Infrastucture.Persistence.Seeds;
using WorkSynergy.WebApi.Extensions;

namespace WorkSynergy.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressMapClientErrors = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddIdentityInfrastructure(builder.Configuration);
            builder.Services.AddApplicationLayer();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddSwaggerExtension();
            builder.Services.AddApiVersioningExtension();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();



            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {

                    var context = services.GetRequiredService<ApplicationContext>();
                    var userManager = services.GetRequiredService<UserManager<WorkSynergyUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await DefaultRoles.SeedAsync(userManager, roleManager);
                    await DefaultFreelancer.SeedAsync(userManager, roleManager);
                    await DefaultClient.SeedAsync(userManager, roleManager);
                    await AbilitySeeding.SeedAsync(context);
                    await ContractOptionsSeeding.SeedAsync(context);
                    await CurrencySeeding.SeedAsync(context);
                    await TagSeeding.SeedAsync(context);
                    await PostSeeding.SeedAsync(context);


                }
                catch (Exception ex)
                {

                }
            }



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHealthChecks("/health");
            app.UseSession();
            app.MapControllers();

            app.Run();
        }
    }
}
