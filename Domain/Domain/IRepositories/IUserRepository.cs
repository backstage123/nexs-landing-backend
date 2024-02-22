using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> InsertAsync(ProviderUserAccount user);

        Task<ProviderUserAccount>? GetByUserName(string userName);

        Task<bool> UpdateAsync(ProviderUserAccount user);

        Task<bool> DeleteAsync(ProviderUserAccount user);
    }
}
