using BL.DTOs;
using BL.DTOs.Users;
using BL.Managers.Users;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configration;
        private UserManager<CustomUser> _userManagerExists;
        private IUserManager _userManager;
        public UserController(IConfiguration configuration, UserManager<CustomUser> userManagerExists,IUserManager UserManager)
        {   
            _configration = configuration;
            _userManagerExists = userManagerExists;
            _userManager=UserManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> register(RegisteDto registeDto)
        {
            var newUser = new CustomUser { UserName = registeDto.name, Email = registeDto.email };

            var result = await _userManagerExists.CreateAsync(newUser, registeDto.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            List<Claim> myCliams = new List<Claim>()
            { new Claim(ClaimTypes.NameIdentifier,newUser.Id),
                new Claim(ClaimTypes.NameIdentifier,registeDto.name),
                new Claim(ClaimTypes.Email,registeDto.email),
                new Claim(ClaimTypes.Role,"user")
            };

            await _userManagerExists.AddClaimsAsync(newUser, myCliams);
            return Ok("created");
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TakenDto>?> Login(LoginDTO loginDTO)
        {

            var user = await _userManagerExists.FindByEmailAsync(loginDTO.email);

            if (user == null)
            {
                return Unauthorized();
            }

            bool isvalid = await _userManagerExists.CheckPasswordAsync(user, loginDTO.password);
            if (!isvalid)
            {
                return Unauthorized();
            }
            var claims = await _userManagerExists.GetClaimsAsync(user);



            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = _configration.GetValue<string>("sekretKey");
            if(Key==null)
            {
                return null;
            }
            var keyBytes = Encoding.ASCII.GetBytes(Key);
            var secKey = new SymmetricSecurityKey(keyBytes);
            var mySigningCredentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
            var expireDate = DateTime.Now.AddMinutes(10);
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = mySigningCredentials,

            };
            var token = tokenHandler.CreateToken(descriptor);
            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TakenDto(tokenAsString, expireDate);
        }

        //[HttpGet]
        //[Route("users")]
        //public  IEnumerable<UserDto>? getUsers()
        //{
        //    return  _userManager.getAll();
        //}
    }
}
