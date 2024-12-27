using AutoMapper;
using CareerX.API.CompanyAdmin.RequestObject;
using CareerX.API.JobSeeker.RequestObject;
using CareerX.Controllers;
using Domain.Services.Login.DTOs;
using Domain.Services.Login;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Login.Interface;
using Domain.Services.Company.Interface;
using Domain.Services.Company.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CareerX.API.CompanyAdmin
{
   
    [ApiController]
    public class CompanyAdminController :BaseApiController<CompanyAdminController>
    {
        public IMapper _mapper { get; set; }
        public ISignUpRequestService _companyAdminSignupService { get; set; }
        public ILoginRequestService _loginRequestService { get; set; }
        public ICompanyService _companyService { get; set; }

        public CompanyAdminController(IMapper mapper, ISignUpRequestService ICompanyAdminSignupService, ILoginRequestService loginRequestService, ICompanyService companyService)
        { 
            _mapper = mapper;
            _companyAdminSignupService = ICompanyAdminSignupService;
            _loginRequestService = loginRequestService;
            _companyService = companyService;
        }

        [HttpPost]
        [Route("company-admin/signup")]
        public async Task<IActionResult> CompanyAdminSignupInContoller(CompanyAdminSignupRequestObject CompanyAdminSignupRequestObject)  
        {
            var companyAdminSignupRequestDto = _mapper.Map<CompanyAdminSignUpRequestDTOs>(CompanyAdminSignupRequestObject);
            _companyAdminSignupService.CompanyAdminSignupInServiceCreation(companyAdminSignupRequestDto);
            return Ok(CompanyAdminSignupRequestObject);
        }

        [HttpGet]
        [Route("company-admin/signup/{companyAdminSignupRequestId}/verify-email")]
        public async Task<IActionResult> VerifyCompanyAdminEmail(Guid companyAdminSignupRequestId)
        {
            var isCompanyAdminVerified = await _companyAdminSignupService.VerifyCompanyAdminAsync(companyAdminSignupRequestId);
            if (isCompanyAdminVerified)
            {
                return Ok("Email Verified");
            }
            else
            {
                return BadRequest("Email Not Verified");
            }
        }

        [HttpPost]
        [Route("company-admin/signup/{companyAdminSignupRequestId}/set-password")]
        public async Task<ActionResult> CompanyAdminSignupInController(Guid companyAdminSignupRequestId, [FromBody] string password)
        {
            await _companyAdminSignupService.CreateCompany(companyAdminSignupRequestId, password);
            return Ok("Password Set Successfully");
        }

        [HttpPost]
        [Route("company-admin/login")]
        public async Task<IActionResult> CompanyAdminLoginInContoller(CompanyAdminLoginRequestObject loginData)
        {
            var loginAfterMap = _mapper.Map<CompanyLoginDto>(loginData);
            var user = _loginRequestService.CompanyLogin(loginAfterMap);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);

        }

        [HttpPut]
        [Route("company-admin/{companyId}/update-company-details")]
        [Authorize]
        public async Task<ActionResult> UpdatePassword(Guid companyId, CompanyDetailsRequestObject companyDetailsRequestObject)
        {
            var mappedCompanyDetailsRequestObject = _mapper.Map<CompanyDto>(companyDetailsRequestObject);
            await _companyService.UpdateCompanyDetails(companyId, mappedCompanyDetailsRequestObject);
            return Ok("Company Details Updated Successfully");
        }




    }
}
