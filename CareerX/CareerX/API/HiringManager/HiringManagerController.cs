using AutoMapper;
using CareerX.API.HiringManager.RequestObject;
using CareerX.Controllers;
using Domain.Models;
using Domain.Services.HiringManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.HiringManager
{
 
    [ApiController]
    public class HiringManagerController : BaseApiController<HiringManagerController>
    {
        IJobService _jobService;
        private IMapper _mapper;

        [HttpPost]
        [Route("HiringManager/postjob")]
        public async Task<IActionResult> PostJob(HRPostJobRequestObject post)
        {
            //var mappedObj = _mapper.Map<>();
            await _jobService.PostJobService(mappedObj);
            return Ok();
        }
    }
}
