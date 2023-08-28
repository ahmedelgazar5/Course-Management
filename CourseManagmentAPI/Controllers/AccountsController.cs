using CourseManagmentBLL.DTO.AccountDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountsController
            (UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] CoursesLoginDto LoginDto)
        {
            if (ModelState.IsValid == true)
            {
                var user = await _userManager.FindByEmailAsync(LoginDto.Email);
                if (user == null) throw new Exception("Email is not valide!!");

                var signInStatus = await _signInManager.PasswordSignInAsync(LoginDto.Email, LoginDto.Password, true, true);
                if (!signInStatus.Succeeded) throw new Exception("Email or Password is not correct!!");

                //Generate Token (claims)
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ez92utU5UA6ZZG3OmCeDdrcHvmewvNZA"));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtHandler = new JwtSecurityTokenHandler();

                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>()
            {
                new Claim("id",user.Id),
                new Claim("email",user.Email)
            };

                foreach (var role in roles)
                {
                    claims.Add(new Claim("role", role));
                }

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: "CourseApp",
                    audience: "user",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signingCredentials);

                string jwt = jwtHandler.WriteToken(jwtSecurityToken);

                //return token for user
                return Ok(jwt);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
