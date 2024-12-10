using AutoMapper;
using CareerX.API.JobSeeker.RequestObject;
using CareerX.Controllers;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.JobSeeker
{

    [ApiController]
    public class JobSeekerController : BaseApiController<JobSeekerController>
    {
        public ISignUpRequestService ijobSeekerSignupService { get; set; }
        public IMapper mapper { get; set; }
        public JobSeekerController(ISignUpRequestService ijobSeekerService, IMapper mapper)
        {
            this.ijobSeekerSignupService = ijobSeekerService;
            this.mapper = mapper;
        }
        //https://localhost/careerx/api/v1/jobseeker/signup  Routepath
        //username, firstname, lastname, phonenumber, email
        [HttpPost]
        [Route("jobseeker/signup")]
        public async Task<IActionResult> JobSeekerSignupInContoller(JobSeekerSignupRequestObject jobSeekerSignupRequestObject)  //(1)first method of signup
        {
            var jobseekerSignupRequestDto = mapper.Map<JobSeekerSignUpRequestDTOs>(jobSeekerSignupRequestObject); //(2)mapping from request object to dto
            ijobSeekerSignupService.JobSeekerSignupInServiceCreation(jobseekerSignupRequestDto);//(3)   passing dto to service layer
            return Ok(jobSeekerSignupRequestObject); // returning response for success 
        }


    }
}
