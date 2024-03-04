using Domain.IRepositories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProviderUserAccount>> GetAll()
        {
            return _context.ProviderUserAccounts.ToList();
        }

        public async Task<bool> DeleteAsync(ProviderUserAccount user)
        {
            //throw new NotImplementedException();
            _context.ProviderUserAccounts?.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProviderUserAccount>? GetByUserNameAsync(string username)
        {
            //throw new NotImplementedException();
            //if (!string.IsNullOrEmpty(username))
            //{
            //    ProviderUserAccount? user = await _context.ProviderUserAccounts.Where(user => user.UserName == username).FirstOrDefaultAsync();
            //    return user;
            //}
            //else
            //{
            //    throw new ArgumentNullException(nameof(username));
            //}
            ProviderUserAccount user = await _context.ProviderUserAccounts.Where(user => user.UserName == username).FirstOrDefaultAsync();
            return user;
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
