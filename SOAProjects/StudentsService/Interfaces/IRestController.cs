using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentsService.Interfaces
{
    interface IRestController<TEntity>
        where TEntity : Entity
    {
        // GET: api/Models
        Task<IQueryable<TEntity>> GetEntities();
        // GET: api/Models/5
        Task<IHttpActionResult> GetEntity(int id);
        // PUT: api/Models/5
        Task<IHttpActionResult> PutEntity(int id, TEntity model);
        // POST: api/Models
        Task<IHttpActionResult> PostEntity(TEntity model);
        // DELETE: api/Models/5
        Task<IHttpActionResult> DeleteEntity(TEntity entity);
    }
}
