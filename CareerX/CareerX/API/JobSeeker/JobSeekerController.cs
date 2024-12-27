using AutoMapper;
using CareerX.API.JobSeeker.RequestObject;
using CareerX.Controllers;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interface;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CareerX.API.JobSeeker
{

    [ApiController]
    public class JobSeekerController : BaseApiController<JobSeekerController>
    {
        public ISignUpRequestService ijobSeekerSignupService { get; set; }
        public IMapper mapper { get; set; }
        public ILoginRequestService loginRequestService { get; set; }
        public JobSeekerController(ISignUpRequestService ijobSeekerService, IMapper mapper, ILoginRequestService loginRequestService)
        {
            this.ijobSeekerSignupService = ijobSeekerService;
            this.mapper = mapper;
            this.loginRequestService = loginRequestService;
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
        [HttpGet]
        [Route("jobseeker/signup/{jobSeekerSignupRequestId}/Verify-Email")]
        public async Task<IActionResult> VerfyJobseekerEmail(Guid jobSeekerSignupRequestId)
        {
            var isJobseekerVerified= await ijobSeekerSignupService.VerifyJobseekerAsync(jobSeekerSignupRequestId);
             if(isJobseekerVerified)
            {
                return Ok("Email Verified");
            }
            else
            {
                return BadRequest("Email Not Verified");
            }
        }

        [HttpPost]
       
        [Route("jobseeker/signup/{jobSeekerSignupRequestId}/setpassword")]
        public async Task<ActionResult> JobSeekerSignupInContoller(Guid jobSeekerSignupRequestId, [FromBody] string password)
        {
            await ijobSeekerSignupService.CreateJobseeker(jobSeekerSignupRequestId, password);
            return Ok("Password Set Successfully");
        }

        [HttpPost]
        [Route("jobseeker/login")]
        public async Task<IActionResult> JobSeekerLoginInContoller(JobSeekerLoginRequestObject logindata)
        {
            var loginAfterMap = mapper.Map<JobSeekerLoginDto>(logindata);
            var  user=  loginRequestService.login(loginAfterMap);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);

        }
    }
}
