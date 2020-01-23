using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSHR.Services.Repositories
{
    public interface IRepository<TModel, TKey>
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetByKey(TKey key);
        Task<TModel> Create(TModel model);
        Task<TModel> Modify(TModel model);
    }
}