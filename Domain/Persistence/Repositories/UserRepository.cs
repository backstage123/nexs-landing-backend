using Domain.IRepositories;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(ProviderUserAccount user)
        {
            throw new NotImplementedException();
        }

        public Task<ProviderUserAccount>? GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(ProviderUserAccount user)
        {
            try
            {
                if (_context != null && user != null)
                {
                    _context.ProviderUserAccounts?.AddAsync(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("----------------Exception Occurred in UserRepository----------------");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------");
                return false;
            }
        }

        public Task<bool> UpdateAsync(ProviderUserAccount user)
        {
            throw new NotImplementedException();
        }
    }
}
