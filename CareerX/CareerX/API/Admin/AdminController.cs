using AutoMapper;
using CareerX.API.Admin.RequestObject;
using CareerX.Controllers;
using Domain.Services.Admin;
using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interface;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.Admin
{
   
    [ApiController]
    public class AdminController : BaseApiController<AdminController>
    {
        private readonly IAdminServices _adminServices;
        private readonly IMapper mapper;
        public ILoginRequestService LoginRequestService;

        public AdminController(IAdminServices adminServices, IMapper mapper, ILoginRequestService loginRequestService)
        {
            _adminServices = adminServices;
            this.mapper = mapper;
            LoginRequestService = loginRequestService;
        }
        [HttpPost]
        [Route("AdminLogin")]
        public async Task<IActionResult> AdminLogin(AdminLoginRequests adminLoginRequests)
        {
            var admin=mapper.Map<AdminLoginDtos>(adminLoginRequests);
            var result = LoginRequestService.AdminLogin(admin);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/GetJobSeekers")]
        public async Task<IActionResult> GetJobSeekers()
        {

            try
            {
                var jobSeekers = await _adminServices.GetJobSeekers();
                return Ok(mapper.Map<List<JobSeekerDtos>>(jobSeekers));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("admin/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {

            try
            {
                var jobProviders = await _adminServices.GetCompanies();
                return Ok(mapper.Map<List<JobProviderDtos>>(jobProviders));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("admin/DeleteJobSeeker/{id}")]
        public void DeleteJobSeekerById(Guid id)
        {
            bool result = _adminServices.DeleteById(id);
            if (result)
            {
                Ok();
            }
            else
            {
                BadRequest("Cant be deleted");
            }

        }
        [HttpPost]
        [Route("admin/AddJobCategory")]
        public async Task<IActionResult> AddJobCategory(CategoryRequests jobCategoryRequests)
        {
            var jobCategory = mapper.Map<CategoryDtos>(jobCategoryRequests);
            var result = await _adminServices.AddJobCategory(jobCategory);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }



    }
}
