using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchClothes.Application.Interfaces;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using SearchClothes.Persistence.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IDataService<User>, UserDataService>();
            services.AddScoped<IUserDataService, UserDataService>();

            services.AddScoped<IDataService<Verification>, VerificationDataService>();
            services.AddScoped<IVerificationDataService, VerificationDataService>();

            services.AddScoped<IDataService<Tag>, TagDataService>();
            services.AddScoped<ITagDataService, TagDataService>();

            services.AddScoped<IDataService<Post>, PostDataService>();
            services.AddScoped<IPostDataService, PostDataService>();

            var connectionString = configuration["DbConnection"];
            services.AddDbContext<SearchClothesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<ISearchClothesDbContext>(provider =>
                provider.GetService<SearchClothesDbContext>());
            return services;
        }
    }
}
