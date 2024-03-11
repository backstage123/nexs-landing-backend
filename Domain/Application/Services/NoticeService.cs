using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public async Task<List<Notice>> FindAllAsync()
        {
            var notices = await _noticeRepository.GetAll();
            return notices;
        }

        public async Task<Notice> FindNoticeAsync(int id)
        {
            var notice = await _noticeRepository.GetByIdAsync(id);
            return notice;
        }

        public async Task<int> CreateAsync(string title, string authorname, string content)
        {
            //var user = ProviderUserAccount.Create(username, providername);

            var notice = Notice.Create(title, authorname);

            if (title != null)
            {
                if (string.IsNullOrEmpty(content))
                {
                    notice.Content = "";
                }
                else
                {
                    notice.Content = content;
                }

                //var noticeCreated = await _noticeRepository.InsertAsync(notice);
                
                var noticeId = await _noticeRepository.InsertAsync(notice);

                //return noticeCreated;
                return noticeId;
            }
            else
            {
                //return false;
                //return -1;
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var notice = await _noticeRepository?.GetByIdAsync(id);
            if (notice != null)
            {
                var success = await _noticeRepository.DeleteAsync(notice);
                return success;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ModifyAsync(int id, string content)
        {
            var notice = await _noticeRepository?.GetByIdAsync(id);
            notice.Content = content;
            if(notice != null)
            {
                var success = await _noticeRepository.UpdateAsync(notice);
                return success;
            }
            else
            {
                return false;
            }
        }
    }
}
