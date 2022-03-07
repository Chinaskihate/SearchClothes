using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Services.Authentication;
using SearchClothes.Application.Services.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICodeSender, CodeSender>();
            services.AddScoped<ITagService, TagService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
