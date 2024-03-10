using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class NoticeService
    {
        private readonly IRepository<Notice, int> _noticeRepository;

        public NoticeService(IRepository<Notice, int> noticeRepository)
        {
            _noticeRepository = noticeRepository;
        }

        //public async Task<List<ProviderUserAccount>> FetchAllAsync()
        //{
        //    var users = await _noticeRepository.GetAll();
        //    return users;
        //}

        public async Task<List<Notice>> FetchAllAsync()
        {
            var notices = await _noticeRepository.GetAll();
            return notices;
        }

        public async Task<bool> CreateAsync(string title, string authorname, string content = "")
        {
            //var user = ProviderUserAccount.Create(username, providername);

            var notice = Notice.Create(title, authorname);

            if (title != null)
            {
                notice.Content = content;

                var noticeCreated = await _noticeRepository.InsertAsync(notice);

                return noticeCreated;
            }
            else
            {
                return false;
            }
        }
    }
}
