using AutoMapper;
using AutoMapper.Internal;
using Domain.Enums;
using Domain.Helpers;
using Domain.Models;
using Domain.Services.Email;
using Domain.Services.Jobseeker;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
 
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.SignUp.Interface;

namespace Domain.Services.SignUp
{
    public class SignUpRequestService:ISignUpRequestService
    {
        ISignUpRequestRepository _iSignUpRequestRepository;
       
        IEmailService emailService;


        IMapper _mapper;
        public SignUpRequestService(ISignUpRequestRepository SignUpRequestRepository, IMapper mapper,IEmailService _emailService)
        {
            _mapper = mapper;
            emailService = _emailService;
            _iSignUpRequestRepository = SignUpRequestRepository;
        }
      public async Task JobSeekerSignupInServiceCreation(JobSeekerSignUpRequestDTOs jobSeekerSignUpRequestDTOs)//(5) Execute JobSeekerSignUp Request implementation method of interface
            //then map it to JobSeekerSignUpRequestDTOs
            //then pass it to JobSeekerSignupInService
        {
            var jobSeekerSignUpRequestDTO = _mapper.Map<JobSeekerSignUpRequestDTOs>(jobSeekerSignUpRequestDTOs);
            _iSignUpRequestService.JobSeekerSignupInService(jobSeekerSignUpRequestDTO);
            

        }
    }
}
