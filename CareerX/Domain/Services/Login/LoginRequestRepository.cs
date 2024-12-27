using Domain.Models;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public class LoginRequestRepository:ILoginRequestRepository
    {
        protected readonly CareerxDbContext _context;
        public LoginRequestRepository(CareerxDbContext context)
        {
            _context = context;
        }

        public Domain.Models.AuthUser GetUserByLoginDto(JobSeekerLoginDto jobSeekerLoginDto)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == jobSeekerLoginDto.Email && e.Password == jobSeekerLoginDto.Password);
            return user;
        }


        public Models.AuthUser GetCompanyByLoginDto(CompanyLoginDto companyLoginDto)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == companyLoginDto.Email && e.Password == companyLoginDto.Password);
            return user;
        }
    }
}
