using System;
using System.Linq;
using System.Threading.Tasks;
using API_CVPortalen.Helpers;
using API_CVPortalen.Helpers.Users;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Auth;
using API_CVPortalen.Models.Database;
using API_CVPortalen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CVPortalen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Context _context;

        public UserController(IUserService userService, Context context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthRequest model)
        {
            var user = await _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { error = "Username or password is incorrect" });

            return Ok(user.ToAuthResponse());
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }


            try
            {
                var user = await _userService.Create(request.ToUser(), request.Password);
                return Ok(new {id = user.Id});
            }
            catch (AppException e)
            {
                return BadRequest(new {error = e.Message});
            }
        }
        
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users.ToSafeResponse());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                return Ok(user.ToSafeResponse());
            }

            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole(Role.Admin))
            {
                if (User.Identity.Name != id.ToString())
                {
                    return Unauthorized();
                }
            }
            try
            {
                var deleted = await _userService.Delete(id);
                if (deleted)
                {
                    return Ok();
                }

                return NotFound();

            }
            catch (AppException e)
            {
                return BadRequest(new {error = e.Message});
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateRequest model)
        {
            if (!User.IsInRole(Role.Admin))
            {
                if (User.Identity.Name != id.ToString())
                {
                    return Unauthorized();
                }
            }
            
            var user = model.ToUser();
            user.Id = id;
            try
            {
                var updated = await _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException e)
            {
                return BadRequest(new {error = e.Message});
            }

        }
    }
}