using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HostBooking.Models.Repositories;
using HostBooking.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HostBooking.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserRepository userRepository;

        public AuthController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("login")]
        [HttpPost]
        public async void LoginAsync([FromBody] LoginRequest data)
        {
            Console.WriteLine(data.Login);
            var login = data.Login;
            var password = data.Password;
            try
            {
                if (!userRepository.IsAuth(login, password))
                {
                    Response.StatusCode = 400;
                    await Response.WriteAsync("Incorrect login or password");
                }
                else
                {
                    var encodedJwt = GetEncodedJwt(login);
                    var serializerSettings = new JsonSerializerSettings();
                    var loginResponse = new LoginResponse {Login = login, Token = encodedJwt};
                    serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    var jsonLoginResponse = JsonConvert.SerializeObject(loginResponse, serializerSettings);
                    await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(jsonLoginResponse));
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                await Response.WriteAsync(e.Message);
            }
        }

        private static string GetEncodedJwt(string login)
        {
            var claims = new List<Claim> {new(ClaimsIdentity.DefaultNameClaimType, login)};
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                claims,
                now,
                now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}