using DataAccessLayer.DAL;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceLayer;
using IAuthorizationService = ServiceLayer.ServiceLayer.IAuthorizationService;

namespace VehicleServiceManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly VehicleServiceManagementSystemContext _dbContext;
        private readonly IAuthorizationService _authorizationService;

        public LoginController(VehicleServiceManagementSystemContext dbContext, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Login user through user details.
        /// </summary>
        /// <param name="userEntered"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User userEntered)
        {
            ResponseHandler response = new ResponseHandler();
            response = _authorizationService.Login(userEntered, response);
            if(response.Token == null)
            {
                return NotFound("User Not Found");
            }
            response.LoggedIn = true;
            return Ok(response);
        }
    }
}
