using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumProject.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
