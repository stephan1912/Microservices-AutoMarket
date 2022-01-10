using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DalLibrary.DTO;
using DalLibrary.Models;
using IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(AutoMarketContext dbContext,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<IdentityRole> roleManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public AutoMarketContext DbContext { get; }
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO model)
        {
            model.roles = "USER";
            var user = new User()
            {
                UserName = model.username,
                Email = model.email,
                FirstName = model.firstName,
                LastName = model.lastName,
                Birthdate = model.birthdate,
                Roles = model.roles
            };
            try
            {

                var result = await UserManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    //await UserManager.AddToRoleAsync(user, model.roles);


                    await DbContext.SaveChangesAsync();

                    await SignInManager.SignInAsync(user, false);
                    var token = await GenerateJwtToken(model.email, user, false);
                    return Ok(new AuthResponse
                    {
                        email = user.Email,
                        jwt = token,
                        username = model.username
                    });
                }
                else
                {

                    foreach (var err in result.Errors)
                    {
                        //resp.ErrorMessage.Add(new CustomErrorMessage { Code = err.Code, Message = err.Description });
                    }
                    return ServiceResponseModel<object>.NotValid("Datele nu sunt valide!").toHttpResponse();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("session")]
        public async Task<ActionResult> Login([FromBody] AuthRequest model)
        {
            var userFromModel = await UserManager.FindByNameAsync(model.username);
            if (userFromModel == null) return ServiceResponseModel<object>.bad(ErrorResponse.InvalidCredentials()).toHttpResponse();

            var loginResult = await SignInManager.PasswordSignInAsync(userFromModel.UserName, model.password, false, false);
            if (loginResult.Succeeded)
            {
                var appUser = userFromModel;// userManager.Users.SingleOrDefault(u => u.Email == model.EmailAddress);
                var token = await GenerateJwtToken(model.username, appUser, false);
                return Ok(new AuthResponse
                {
                    username = appUser.UserName,
                    jwt = token,
                    email = appUser.Email
                });
            }

            return ServiceResponseModel<object>.bad(ErrorResponse.InvalidCredentials()).toHttpResponse();
        }

        private async Task<string> GenerateJwtToken(string email, User user, bool? rememberMe)
        {
            var roles = user.Roles.Split(",");
            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            foreach (var r in roles)
            {
                claims.Add(new Claim("ROLE", r.ToUpper()));
                claims.Add(new Claim(ClaimTypes.Role, r.ToUpper()));
            }

            var expires = DateTime.Now.AddMinutes(30);// Convert.ToDouble(applicationSettings.JWT_ExpireDays));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyWithAMinimumOf16Charachters"));// applicationSettings.JWT_Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "AutoMarket",//applicationSettings.JWT_Issuer,
                "AutoMarket",//applicationSettings.JWT_Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut]
        [Route("edit")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult> Edit([FromBody] UserDTO model)
        {
            var x = User;
            return Ok("USER");
        }
    }
}