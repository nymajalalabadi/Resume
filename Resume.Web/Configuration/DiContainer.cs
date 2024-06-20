using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;

namespace Resume.Web.Configuration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IContactUsRepository, ContactUsRepository>();

            services.AddScoped<IAboutMeRepository, AboutMeRepository>();

            services.AddScoped<IActivityRepository, ActivityRepository>();

            services.AddScoped<IEducationRepository, EducationRepository>();

            services.AddScoped<ICustomerFeedBackRepository, CustomerFeedBackRepository>();

            services.AddScoped<ICustomerLogoRepository, CustomerLogoRepository>();

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IContactUsService, ContactUsService>();

            services.AddScoped<IAboutMeService, AboutMeService>();

            services.AddScoped<IActivityService, ActivityService>();

            services.AddScoped<IEducationService, EducationService>();

            services.AddScoped<ICustomerFeedBackService, CustomerFeedBackService>();

            services.AddScoped<ICustomerLogoService, CustomerLogoService>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();

            #endregion
        }
    }
}
