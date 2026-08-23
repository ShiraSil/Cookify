using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Cookify.BL.Services;
using Cookify.BL;
using Cookify.DAL;
using Cookify.DAL.Repositories;
namespace Cookify.Common
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterSystemServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIngredientService, IngredientService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Cookify.DAL.AppDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}