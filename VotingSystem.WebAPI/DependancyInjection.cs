using VotingSystem.Application.Mappings;

namespace VotingSystem.WebAPI
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddEndpointsApiExplorer();
            return services;
        }
    }
}
