using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;

namespace Service
{
    public static class RegisterServiceProject
    {
        public static void RegisterServiceProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
