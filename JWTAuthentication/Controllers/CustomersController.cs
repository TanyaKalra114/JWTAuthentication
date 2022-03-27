using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        
           => new string[] { "Tanya Kalra", "Aparna Kuls" };
        
    }
}
