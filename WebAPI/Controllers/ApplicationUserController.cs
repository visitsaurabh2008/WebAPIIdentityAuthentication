using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger)
        {
            _userManager = userManager;
            _signInManager = signInManger;
        }

        [HttpPost]
        [Route("Register")]
        // POST :: /api/ApplicationUser/Register
        public async Task<object> PostApplicationUser(ApplicationUserModel User)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = User.userName,
                Email = User.Email,
                FirstName = User.FirstName
            };

            try {
                var result = await _userManager.CreateAsync(applicationUser, User.Password);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }

        }
    }
}
