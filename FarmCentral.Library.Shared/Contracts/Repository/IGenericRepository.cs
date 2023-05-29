using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Contracts.Repository
{
    //Generic repository for table repos to inherit from.
    //Code attribution
    //Author: Per-Erik Bergman
    //Link:https://medium.com/@pererikbergman/repository-design-pattern-e28c0f3e4a30
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> GetAsync();
    }

    //End of code attribution.
}
