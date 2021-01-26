using NET5.JWT.CustomUser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5.JWT.CustomUser.Data
{
    public class UnitOfWork
    {
        protected readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
    }
}
