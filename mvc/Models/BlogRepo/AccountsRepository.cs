using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using mvc.Data;
using mvc.Models.Entites;

namespace mvc.Models.BlogRepo
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _conf;

        public AccountsRepository(SignInManager<IdentityUser> _manager, UserManager<IdentityUser> _userManager, ApplicationDbContext _db, IConfiguration conf)
        {
            this._db = _db;
            _conf = conf;
            this._signInManager = _manager;
            this._userManager = _userManager;
        }

        /// <summary>
        /// Verifies user login
        /// </summary>
        /// <see cref="User"/>
        /// <param name="user">User object to be verified</param>
        /// <returns>User object with a jwt bearer token</returns>
        public async Task<User> VerifyCredentials(User user)
        {
            if (user.Username == null || user.Password == null || user.Username.Length == 0 || user.Password.Length == 0)
            {
                return null;
            }

            var thisUser = await _userManager.FindByNameAsync(user.Username);
            if (thisUser == null)
                return (null);

            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                return null;
            }

            var role = await _userManager.GetRolesAsync(thisUser);
            return new User() { Id = thisUser.Id, Username = user.Username, Role = role.FirstOrDefault() };
        }

        /// <summary>
        /// Generates a token for a user
        /// </summary>
        /// <param name="user">User token will be generated for</param>
        /// <returns>Jwt token string</returns>
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var confKey = _conf.GetSection("TokenSettings")["SecretKey"];
            var key = Encoding.ASCII.GetBytes(confKey);
            var cIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                    //new Claim("roles", user.Role)
                });

            //claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = cIdentity,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;


        }

        public Task<bool> ChangePasswd(User u, string oldP, string newP)
        {
            throw new NotImplementedException();
        }

        public Task<User> ChangeRole(User u, string newR)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(User u)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUser(User u)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}

