using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class AuthorizationDAL : IAuthorizationDAL
    {
        private IConfiguration _configuration;
        private VehicleServiceManagementSystemContext _dbContext;

        public AuthorizationDAL(VehicleServiceManagementSystemContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public ResponseHandler Login(User userEntered, ResponseHandler response)
        {
            string role = "";
            User user = Authenticate(userEntered);
            if (user != null)
            {
                response.UserID = user.Id;
                response.Token = Generate(user.FirstName, user.Password, user.RoleId.ToString());
                return response;
            }
            return response;
        }

        private User Authenticate(User userEntered)
        {
            User CurrentUser = _dbContext.Users.Where(user => user.FirstName.ToLower() == userEntered.FirstName.ToLower()
                && user.Password == userEntered.Password).FirstOrDefault();
            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }

        private string Generate(string name, string password, string role)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                     new Claim(ClaimTypes.Name, name),
                     new Claim("role-user", role),
                     //new Claim(ClaimTypes.Role, role)
                 }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials
                                        (new SymmetricSecurityKey(TokenKey),
                                        SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
