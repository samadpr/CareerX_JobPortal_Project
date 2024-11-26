using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerX.Controllers
{
    [Route("api/v1")]
    public class BaseApiController<T> : ControllerBase
    {
    }
 
}
