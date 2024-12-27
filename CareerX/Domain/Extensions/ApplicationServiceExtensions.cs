
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

namespace Domain.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices1(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CareerxDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("Data Source=ABDUL-SAMAD;Initial Catalog=CareerX_DB;Integrated Security=True;Trust Server Certificate=True"))
            );
            //services.AddTransient<IEmailService, EmailService>();
            //services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
            //services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            //services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
}
