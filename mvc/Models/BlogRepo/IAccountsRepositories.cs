using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models.Entites;

namespace mvc.Models.BlogRepo
{
    public interface IAccountsRepository
    {

        Task<User> VerifyCredentials(User user);
        string GenerateJwtToken(User user);
        Task<bool> ChangePasswd(User u, string oldP, string newP);
        Task<User> ChangeRole(User u, string newR);
        Task<bool> DeleteUser(User u);
        Task<User> AddUser(User u);
        Task<List<User>> GetAllUsers();
    }
}
