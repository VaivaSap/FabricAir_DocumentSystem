using FabricAir_DocumentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FabricAir_DocumentSystem.Services
{
    public class AccessService
    {
        private readonly SystemContext _context;

        public AccessService(SystemContext context)
        {
            _context = context;
        }

        public List<AccessScope> GetUsersAccessScope(string userName)
        {
            var user = _context.Users.FirstOrDefault(s => s.Name == userName);

            if (user == null)
            {
                return new List<AccessScope>();
            }

            var userRoleId = user.UserRoleId;



            var accessScopes = _context.AcessScope.Where(a => a.UserRoleId == userRoleId).ToList();


            return accessScopes;

        }
    }
}
