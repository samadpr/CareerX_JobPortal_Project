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
        [Route("admin/add-job-skill")]
        public async Task<IActionResult> AddJobSkill(SkillRequest jobSkillRequests)
        {
            var jobSkill = mapper.Map<SkillsDtos>(jobSkillRequests);
            var result = await _adminServices.AddSkillAsync(jobSkill);
            if (result != null)
            {
                return Ok(jobSkill.Name + " Added Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpDelete]
        [Route("admin/delete-job-skill/{id}")]
        public async Task<IActionResult> DeleteJobSkillById(Guid id)
        {
            var result = await _adminServices.RemoveSkillAsync(id);
            if (result)
            {
                return Ok(" Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/get-all-skills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _adminServices.GetSkills();
            if (result != null)
            {
                return Ok(mapper.Map<List<SkillsDtos>>(result));
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpPost]
        [Route("admin/add-location")]
        public async Task<IActionResult> AddJobLocation(LocationRequests jobLocationRequests)
        {
            var jobLocation = mapper.Map<LocationDtos>(jobLocationRequests);
            var result = await _adminServices.AddLocation(jobLocation);
            if (result != null)
            {
                return Ok(jobLocation.Name + " Added Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpDelete]
        [Route("admin/delete-location/{id}")]
        public async Task<IActionResult> DeleteJobLocationById(Guid id)
        {
            var result = await _adminServices.RemoveLocation(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/get-all-locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _adminServices.GetAllLocations();
            if (result != null)
            {
                return Ok(mapper.Map<List<LocationDtos>>(result));
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpPost]
        [Route("admin/add-qualification")]
        public async Task<IActionResult> AddQualification(QualificationRequest qualificationRequest)
        {
            var qualification = mapper.Map<QualificationDtos>(qualificationRequest);
            var result = await _adminServices.AddQualification(qualification);
            if (result != null)
            {
                return Ok(qualification.Name + " Added Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpDelete]
        [Route("admin/delete-qualification/{id}")]
        public async Task<IActionResult> DeleteQualificationById(Guid id)
        {
            var result = await _adminServices.RemoveQualification(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/get-all-qualifications")]
        public async Task<IActionResult> GetAllQualifications()
        {
            var result = await _adminServices.GetAllQualifications();
            if (result != null)
            {
                return Ok(mapper.Map<List<QualificationDtos>>(result));
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpPost]
        [Route("admin/add-industry")]
        public async Task<IActionResult> AddIndustry(IndustriesRequests industriesRequests)
        {
            var industries = mapper.Map<IndustryDtos>(industriesRequests);
            var result = await _adminServices.AddIndustries(industries);
            if (result != null)
            {
                return Ok(industries.Name + " Added Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpDelete]
        [Route("admin/delete-industry/{id}")]
        public async Task<IActionResult> DeleteIndustryById(Guid id)
        {
            var result = await _adminServices.RemoveIndustries(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/get-all-industries")]
        public async Task<IActionResult> GetAllIndustries()
        {
            var result = await _adminServices.GetIndustries();
            if (result != null)
            {
                return Ok(mapper.Map<List<IndustryDtos>>(result));
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
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

        [HttpDelete]
        [Route("admin/delete-category/{id}")]
        public async Task<IActionResult> DeleteJobCategoryById(Guid id)
        {
            var result = await _adminServices.RemoveJobCategory(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }

        [HttpGet]
        [Route("admin/get-all-job-categories")]
        public async Task<IActionResult> GetAllJobCategories()
        {
            var result = await _adminServices.GetJobCategories();
            if (result != null)
            {
                return Ok(mapper.Map<List<CategoryDtos>>(result));
            }
            else
            {
                return BadRequest("Invalid request. Please use Admin credentials.");
            }
        }
    }
}
