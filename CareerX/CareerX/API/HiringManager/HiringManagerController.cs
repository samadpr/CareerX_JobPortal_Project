using AutoMapper;
using CareerX.API.HiringManager.RequestObject;
using CareerX.Controllers;
using Domain.Services.HiringManager;
using Domain.Services.HiringManager.Interface;
using Domain.Services.Job.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.HiringManager
{
 
    [ApiController]
    public class HiringManagerController : BaseApiController<HiringManagerController>
    {
        public IMapper _mapper;
        public IJobService _jobPostService;

        public HiringManagerController(IMapper mapper,IJobService jobService)
        {
            _mapper = mapper;
            _jobPostService = jobService;
        }

        [HttpPost]
        [Route("HiringManager/postjob")]
        public async Task<IActionResult> PostJob(HRPostJobRequestObject post)
        {
            JobPostDtos jobPostDto = _mapper.Map<JobPostDtos>(post);
            _jobPostService.JobPostService(jobPostDto);
            return Ok(jobPostDto);
        }
        [HttpDelete]
        [Route("HiringManager/removeJob")]
        public async Task<IActionResult> RemoveJob(Guid jobIdToRemove)
        {
            try
            {
                _jobPostService.RemoveJobService(jobIdToRemove);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("HiringManager/getalljobs")]
        public async Task<IActionResult> GetAllJobs(Guid companyId)
        {
            return Ok(_jobPostService.ListPostedJobs(companyId));
        }

    }
}
