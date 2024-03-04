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

        Task<List<ProviderUserAccount>> GetAll();

        Task<ProviderUserAccount>? GetByUserNameAsync(string userName);

        Task<bool> UpdateAsync(ProviderUserAccount user);

        Task<bool> DeleteAsync(ProviderUserAccount user);
    }
}
