using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Persistence.Contracts
{
    //implementation of repositories is in Infrastructure folder
    //implemented relative to a class called T
    //generic functions that every db does
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        
        //once data is pulled from db, it is readonly and cannot be modified
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> IsExists(int id);

    }
}
