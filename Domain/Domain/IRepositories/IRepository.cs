using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRepository<T, Tid>
    {
        Task<Tid> InsertAsync(T entity);

        Task<List<T>>? GetAll();

        Task<T>? GetByIdAsync(Tid id);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);
    }
}
