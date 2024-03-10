using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class NoticeRepository : IRepository<Notice, int>
    {
        private readonly ApplicationDbContext _context;

        public NoticeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notice>> GetAll()
        {
            return _context.Notice.ToList();
        }

        public Task<bool> DeleteAsync(Notice user)
        {
            throw new NotImplementedException();
        }

        public async Task<Notice>? GetByIdAsync(int id)
        {
            //ProviderUserAccount user = await _context.ProviderUserAccounts.Where(user => user.UserName == username).FirstOrDefaultAsync();
            //return user;
            Notice notice = await _context.Notice.Where(notice => notice.Id == id).FirstOrDefaultAsync();
            return notice;
        }

        public async Task<bool> InsertAsync(Notice notice)
        {
            if (_context != null && notice != null)
            {
                _context.Notice?.AddAsync(notice);
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> UpdateAsync(Notice user)
        {
            throw new NotImplementedException();
        }

        //public Task<Notice>? GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
