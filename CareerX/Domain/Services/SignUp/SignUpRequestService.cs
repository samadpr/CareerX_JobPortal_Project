using AutoMapper;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp
{
    public class SignUpRequestService:ISignUpRequestService
    {
        ISignUpRequestService _iSignUpRequestService;
        IMapper _mapper;
        public SignUpRequestService(ISignUpRequestService iSignUpRequestService,IMapper mapper)
        {
            _mapper = mapper;
            _iSignUpRequestService = iSignUpRequestService;
        }
      public async void JobSeekerSignupInService(JobSeekerSignUpRequestDTOs jobSeekerSignUpRequestDTOs)//(5) Execute JobSeekerSignUp Request implementation method of interface
            //then map it to JobSeekerSignUpRequestDTOs
            //then pass it to JobSeekerSignupInService
        {
            var jobSeekerSignUpRequestDTO = _mapper.Map<JobSeekerSignUpRequestDTOs>(jobSeekerSignUpRequestDTOs);
            _iSignUpRequestService.JobSeekerSignupInService(jobSeekerSignUpRequestDTO);
            return Ok(jobSeekerSignUpRequestDTO);

        }
    }
}
