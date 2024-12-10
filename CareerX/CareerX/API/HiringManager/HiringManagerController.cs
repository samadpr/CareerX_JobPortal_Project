using CareerX.API.HiringManager.RequestObject;
using CareerX.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.HiringManager
{
 
    [ApiController]
    public class HiringManagerController : BaseApiController<HiringManagerController>
    {
        [HttpPost]
        [Route("HiringManager/postjob")]
        public async Task<IActionResult> PostJob(HRPostJobRequestObject post)
        {

            return Ok();
        }
    }
}
