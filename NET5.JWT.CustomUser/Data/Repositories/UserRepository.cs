using Microsoft.EntityFrameworkCore;
using NET5.JWT.CustomUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5.JWT.CustomUser.Data.Repositories
{
    public class UserRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(string email, string password)
        {
            return await _context.Users.Include(f=>f.UserRoles).ThenInclude(f=>f.Role).Where(f=>f.Email == email && f.Password == password).FirstOrDefaultAsync();
        }
    }
}
