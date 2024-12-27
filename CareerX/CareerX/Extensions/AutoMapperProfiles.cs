using AutoMapper;
using CareerX.API.CompanyAdmin.RequestObject;
using CareerX.API.JobSeeker.RequestObject;
using Domain.Models;
using Domain.Services.Company.DTOs;
using Domain.Services.Login.DTOs;
using Domain.Services.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<JobSeekerSignUpRequestDTOs, SignUpRequest>().ReverseMap();
            CreateMap<JobSeekerSignupRequestObject, JobSeekerSignUpRequestDTOs>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<JobSeekerLoginRequestObject,JobSeekerLoginDto>().ReverseMap();
            CreateMap<AuthUser, JobSeekerLoginDto>().ReverseMap();

            CreateMap<SignUpRequest,AuthUser>().ReverseMap();

            CreateMap<CompanyAdminSignupRequestObject, CompanyAdminSignUpRequestDTOs>().ReverseMap();
            CreateMap<CompanyAdminSignUpRequestDTOs, SignUpRequest>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyAdmin>().ReverseMap();
            CreateMap<CompanyAdminLoginRequestObject, CompanyLoginDto>().ReverseMap();
            CreateMap<AuthUser, CompanyLoginDto>().ReverseMap();

            CreateMap<CompanyDetailsRequestObject, CompanyDto>().ReverseMap();
            CreateMap<CompanyAdmin, CompanyDto>().ReverseMap();
        }
    }
}
