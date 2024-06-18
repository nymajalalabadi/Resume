﻿using Resume.Bussines.Services.Implementation;
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

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IContactUsService, ContactUsService>();

            services.AddScoped<IAboutMeService, AboutMeService>();

            services.AddScoped<IActivityService, ActivityService>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();

            #endregion
        }
    }
}
