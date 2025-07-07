using inventure.Models.Payloads;
using inventure.Models.Response;
using inventure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace inventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public LoginResponse Login([FromBody] LoginRequestPayload request)
        {
            return _loginService.Login(request);
        }
    }
}
