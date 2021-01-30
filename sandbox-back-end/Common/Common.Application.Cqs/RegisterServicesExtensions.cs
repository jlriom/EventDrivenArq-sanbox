using Common.Application.Cqs.Contracts;
using Common.Application.Cqs.Implementation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Common.Application.Cqs
{
    public static class RegisterServicesExtensions
    {
        public static void AddCqsServices(this IServiceCollection services, params Type[] types)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            services.AddMediatR(types.Select(t => t.Assembly).ToArray());
        }
    }
}