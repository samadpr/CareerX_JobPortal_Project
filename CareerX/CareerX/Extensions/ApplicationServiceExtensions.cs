using Domain.Models;
using Domain.Services.Email;
using Domain.Services.SignUp.Interface;
using Domain.Services.SignUp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Extensions;
using Domain.Services.AuthUser.Interface;
using Domain.Services.AuthUser;
using Domain.Services.Login.Interface;
using Domain.Services.Login;
using Domain.Services.Company.Interface;
using Domain.Services.Company;
using Domain.Services.HiringManager.Interface;
using Domain.Services.HiringManager;
using Domain.Services.Admin.Interface;
using Domain.Services.Admin;


namespace CareerX.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices1(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CareerxDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("Data Source=LAPTOP-5M9L3AJN\\MSSQLSERVER02;Initial Catalog=careerX;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            );
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepo>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository > ();
            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminServices, AdminService>();

            return services;
        }
    }
}
