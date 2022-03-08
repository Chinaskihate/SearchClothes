using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Application.Services.Authentication;
using SearchClothes.Application.Services.Posts;
using SearchClothes.Application.Services.Tags;
using SearchClothes.Application.Services.Users;
using System.Reflection;

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
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
