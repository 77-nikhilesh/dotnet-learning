using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using MyProject.API.DTOs;
using Microsoft.AspNetCore.Identity;
using MyProject.API.Repositories;

namespace MyProject.API.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) 
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
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

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.UserName);
            if(user != null)
            {
                var userPass = await userManager.CheckPasswordAsync(user, loginRequest.Password);
                if (userPass)
                {
                    //get user roles
                    var roles = await userManager.GetRolesAsync(user);
                    //create token
                    var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                    var response=new LoginResponseDto
                    {
                        jwtToken = jwtToken
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Invalid password");
                }
            }
            else
            {
                return BadRequest("User not found");
            }
        }
   }
}
