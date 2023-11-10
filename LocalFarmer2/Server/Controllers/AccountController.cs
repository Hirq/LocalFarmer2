using LocalFarmer2.Server.Models;
using LocalFarmer2.Server.Repositories;
using LocalFarmer2.Shared.Utilities;
using LocalFarmer2.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IFarmhouseRepository _farmhouseRepository;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IApplicationUserRepository applicationUserRepository,
            IFarmhouseRepository farmhouseRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _applicationUserRepository = applicationUserRepository;
            _farmhouseRepository = farmhouseRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AddUser([FromBody] RegisterModel model)
        {
            var newUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult
                {
                    Successful = false,
                    Errors = errors
                });
            }

            return Ok(new RegisterResult
            {
                Successful = true,
            });
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new LoginResult
                {
                    Successful = false,
                    Error = "User and password isn't correct"
                });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }

        [HttpGet]
        [Route("User/{userName}")]
        public async Task<IActionResult> GetCurrentUserAsync(string userName)
        {
            var user = await _applicationUserRepository.GetFirstOrDefaultAsync(x => x.UserName == userName);
            var userDto = new UserModel()
            {
                Name = user.UserName,
                IdFarmhouse = user.IdFarmhouse
            };
            return Ok(userDto);
        }
    }
}
