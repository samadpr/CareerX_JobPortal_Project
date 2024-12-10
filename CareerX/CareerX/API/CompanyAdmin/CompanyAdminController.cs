using CareerX.Controllers;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.API.CompanyAdmin
{
   
    [ApiController]
    public class CompanyAdminController :BaseApiController<CompanyAdminController>
    {
        [Route("company-admin/register-company")]
        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return RedirectToAction();
        }
        
    }
}
