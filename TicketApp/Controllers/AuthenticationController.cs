using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Interfaces;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(UserManager<Users> userManager, IMapper mapper, IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
        }


        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<Users>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            if(!result.Succeeded) 
            {
                foreach(var error in result.Errors) 
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
            return StatusCode(201);
        }


        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }
        
    }
}
