using inventure.DBContexts;
using inventure.Models.Payloads;
using inventure.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace inventure.Services.impl
{
    public class LoginService : ILoginService
    {
        private readonly UserManagementDBContexts _dBContexts;
        private readonly IConfiguration _config;
        private readonly IUserManagementService _userService;

        public LoginService(UserManagementDBContexts dBContexts, IConfiguration config, IUserManagementService userService)
        {
            _dBContexts = dBContexts;
            _config = config;
            _userService = userService;
        }

        public LoginResponse Login(LoginRequestPayload request)
        {
            var user = _dBContexts.usermasters
                .FirstOrDefault(u => u.UserName == request.Username && u.Email == request.Email);

            if (user == null)
            {
                return new LoginResponse
                {
                    statuscode = 420,
                    Message = "Invalid credentials"
                };
            }

            var token = GenerateJwtToken(user.UserName, user.Email);

            return new LoginResponse
            {
                statuscode = 200,
                Token = token,
                Message = "Login successful"
            };
        }

        public string GenerateJwtToken(string userName, string email)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryInMinutes = int.Parse(jwtSettings["ExpireMinutes"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
