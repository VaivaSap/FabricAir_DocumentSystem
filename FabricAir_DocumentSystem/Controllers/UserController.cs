using FabricAir_DocumentSystem.Models;
using FabricAir_DocumentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricAir_DocumentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
       private readonly SystemContext _context;
       private readonly AccessService _accessService;

        public UserController(SystemContext context, AccessService accessService)
        {
            _context = context;
            _accessService = accessService;
        }


        //c) Get all users.


        [HttpGet("all-users")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }


        //d) Get specific user info by username.

        [HttpGet("user/{userName}")]
        public IActionResult GetUserInfo(string userName)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Name == userName);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}
