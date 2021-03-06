﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRE.Core.Extensions;
using MyRE.Core.Models.Domain;
using MyRE.Core.Services;

namespace MyRE.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService _user;

        public UsersController(IUserService userService)
        {
            _user = userService;
        }

        [HttpGet("Me")]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetLoggedInUser()
        {
            var user = await _user.GetAuthenticatedUserFromContextAsync(HttpContext);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(void), 401)]
        public async Task<IActionResult> RetrieveUser(string userId)
        {
            var currentUser = await _user.GetAuthenticatedUserFromContextAsync(HttpContext);

            if (await _user.UserCanAccessUserDataAsync(currentUser, userId))
            {
                return Ok(await _user.GetUserAsync(userId));
            }
            else {
                return Unauthorized();
            }
        }

        [HttpGet("{userId}/Instances")]
        public async Task<IActionResult> ListUserInstances(string userId)
        {
            var currentUser = await _user.GetAuthenticatedUserFromContextAsync(HttpContext);
            if (await _user.UserCanAccessUserDataAsync(currentUser, userId))
            {
                return Ok((await _user.GetUserInstancesAsync(userId)).Select(i => i.ToDomainModel()));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}