using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeBikeAPI.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity item);
        Task<TEntity> Get(int id);
        Task Delete(int id);
        Task<TEntity> Update(TEntity item);
    }
}
