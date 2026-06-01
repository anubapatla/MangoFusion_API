using MangoFusion_API.Models;
using MangoFusion_API.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MangoFusion_API.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly String secretKey;
        public AuthController(ApiResponse response, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {

            secretKey = configuration.GetValue<string>("ApiSettings:Secret") ?? "";
            _response = response;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       [HttpPost("register")]
        public async Task<IActionResult>Register([FromBody] RegisterRequestDTO model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser newUser = new()
                {
                    UserName = model.Email,
                    Name= model.Name,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                     _response.IsSuccess = true;
                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

            }
            else
            {
                
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                foreach(var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _response.ErrorMessage.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(_response);
            }
            
        }
    }
}
