using AutoMapper;
using Domain.Services.AuthUser.Interface;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public class LoginRequestService:ILoginRequestService
    {
        ILoginRequestRepository loginJobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        public LoginRequestService(ILoginRequestRepository jobSeekerRepository, IAuthUserRepository authUserRepository, IMapper mapper)
        {
            this.loginJobSeekerRepository = jobSeekerRepository;
            this.authUserRepository = authUserRepository;
            this.mapper = mapper;
        }
        public  JobSeekerLoginDto login(JobSeekerLoginDto dto)
        {
        
           var user= loginJobSeekerRepository.GetUserByLoginDto(dto);
            if (user == null)
            {
                return null;
            }
            else
            {
                var userReturn = mapper.Map<JobSeekerLoginDto>(user);
                userReturn.Token = authUserRepository.CreateToken(user);
                    return userReturn;
            }

        }
       
        public Models.AuthUser AdminLogin(AdminLoginDtos admin)
        {
           return loginJobSeekerRepository.AdminLogin(admin);
        }


        public CompanyLoginDto CompanyLogin(CompanyLoginDto dto)
        {

            var company = loginJobSeekerRepository.GetCompanyByLoginDto(dto);
            if (company == null)
            {
                return null;
            }
            else
            {
                var returnCompany = mapper.Map<CompanyLoginDto>(company);
                returnCompany.Token = authUserRepository.CreateToken(company);
                return returnCompany;
            }

        }






    }
}
