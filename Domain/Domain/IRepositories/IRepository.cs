using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRepository<T>
    {
        Task<bool> InsertAsync(T user);

        Task<T>? GetByUserName(string userName);

        Task<bool> UpdateAsync(T user);

        Task<bool> DeleteAsync(T user);
    }
}
