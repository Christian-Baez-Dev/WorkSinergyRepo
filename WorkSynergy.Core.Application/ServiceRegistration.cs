﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WorkSynergy.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Mapping
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion

 
        }
    }
}
