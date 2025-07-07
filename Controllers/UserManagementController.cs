using inventure.Models.Payloads;
using inventure.Models.Response;
using inventure.Repositories;
using inventure.Services;
using inventure.Services.impl;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace inventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpPost("CreateUser")]

            public response CreateUser(Userpayload payload)
            {
                return _userManagementService.CreateUser(payload);
            }
        
    }
}
