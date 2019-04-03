using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentsProject.Interfaces
{
    interface IRestController<TEntity>
        where TEntity : Entity
    {
        // GET: api/Models
        IQueryable<TEntity> GetEntities();
        // GET: api/Models/5
        IHttpActionResult GetEntity(int id);
        // PUT: api/Models/5
        IHttpActionResult PutEntity(int id, TEntity model);
        // POST: api/Models
        IHttpActionResult PostEntity(TEntity model);
        // DELETE: api/Models/5
        IHttpActionResult DeleteEntity(TEntity entity);
    }
}
