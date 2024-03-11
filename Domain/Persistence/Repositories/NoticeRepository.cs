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

        public async Task<Notice>? GetByIdAsync(int id)
        {
            //ProviderUserAccount user = await _context.ProviderUserAccounts.Where(user => user.UserName == username).FirstOrDefaultAsync();
            //return user;
            Notice notice = await _context.Notice.Where(notice => notice.Id == id).FirstOrDefaultAsync();
            return notice;
        }

        public async Task<int> InsertAsync(Notice notice)
        {            
            _context?.Notice?.AddAsync(notice);
            await _context?.SaveChangesAsync();

            return notice.Id;
        }

        public async Task<bool> UpdateAsync(Notice notice)
        {
            Notice noticeToUpdate = await _context?.Notice?.Where(n => n.Id == notice.Id).FirstOrDefaultAsync();
            noticeToUpdate.Content = notice.Content;
            noticeToUpdate.Updated = DateTime.Now;
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<bool> DeleteAsync(Notice notice)
        {
            //throw new NotImplementedException();
            _context.Notice?.Remove(notice);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
