using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Persistence.Contracts
{
    //implemented relative to a class called T
    //generic functions that every db does
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        
        //once data is pulled from db, it is readonly and cannot be modified
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);


    }
}
