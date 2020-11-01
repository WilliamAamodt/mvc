using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models.BlogRepo;
using mvc.Models.Entites;
/*
 * Kode av hentet fra JWT Eksempel kode av Knut Collin.
 * Ikke noe orignal kode fra min side.
 */
namespace mvc.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    //[ApiController]
    public class MyAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAccountsRepository _repo;

        public MyAccountsController(UserManager<IdentityUser> userManager, ApplicationDbContext appDbContext, IAccountsRepository repo)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("verifyLogin")]
        public async Task<IActionResult> VerifyLogin(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User res = await _repo.VerifyCredentials(user);

            if (res == null)
            {
                return Ok(new { res = "Brukernavn/Passord er feil" });
            }

            return new ObjectResult(_repo.GenerateJwtToken(res));
        }

    }
}
