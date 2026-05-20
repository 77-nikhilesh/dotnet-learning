using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using MyProject.API.DTOs;
using Microsoft.AspNetCore.Identity;

namespace MyProject.API.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager) 
        {
            this.userManager = userManager;

        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
           var identityUser = new IdentityUser
           {
               UserName = registerRequest.UserName,
               Email = registerRequest.UserName
           };

            var identityresult =await userManager.CreateAsync(identityUser, registerRequest.Password);
            if(identityresult.Succeeded)
            {
                if(registerRequest.Roles != null && registerRequest.Roles.Length > 0)
                {
                    await userManager.AddToRolesAsync(identityUser, registerRequest.Roles);
                    if (identityresult.Succeeded)
                    {
                        return Ok("Register successful");
                    }
                }
              
              
            }
            return BadRequest(identityresult.Errors);
        }
    }
}
