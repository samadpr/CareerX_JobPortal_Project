using AutoMapper;
using CareerX.API.JobSeeker.RequestObject;
using Domain.Models;
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
        }
    }
}
