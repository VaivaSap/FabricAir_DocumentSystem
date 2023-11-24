using FabricAir_DocumentSystem.Models;
using FabricAir_DocumentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace FabricAir_DocumentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FileController : Controller
    {
        private readonly SystemContext _context;

        private readonly AccessService _accessService;

        public FileController(SystemContext context, AccessService accessService)
        {
            _context = context;
            _accessService = accessService;
        }


        //a) Get all groups of files by user name.
    
        [HttpGet("all/{userName}")]

        public async Task<IActionResult> GetAllUsersFiles(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);

            if (user == null)
            {
                return NotFound($"User with username '{userName}' not found.");
            }

            var userFiles = _context.Files.Where(u => u.UserId == user.Id).ToList();

            return Ok(userFiles);
        }

        //b) Get a separate group of files by user name.

        [HttpGet("{fileType}/{userName}")]
        public async Task<IActionResult> GetFilesByFileType(string fileType, string userName)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);

            if (user == null)
            {
                return NotFound($"User with username '{userName}' not found.");
            }



            var accessScopes = _accessService.GetUsersAccessScope(userName);

            var fileTypes = _context.FileTypes.FirstOrDefault(f => f.FileType == fileType);

            if (fileTypes == null)
            {
                return Ok(new List<Files>());
            }

            var fileTypeId = fileTypes.Id;

            var allowedFileTypes = accessScopes.Select(o => o.FileTypeId).ToList();
            var filesByType = _context.Files
                .Where(u => u.UserId == user.Id && u.FileTypeId == fileTypeId && allowedFileTypes.Contains(u.FileTypeId))
                    .ToList();
            

            return Ok(filesByType);
        }
    }
}





