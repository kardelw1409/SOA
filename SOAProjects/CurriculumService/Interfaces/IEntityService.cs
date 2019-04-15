using CurriculumService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CurriculumService.Interfaces
{
    public interface IEntityCrudService<TEntity> : IDisposable
        where TEntity : Entity
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);
        Task<TEntity> Remove(int id);
        Task Update(TEntity item);
    }
}   