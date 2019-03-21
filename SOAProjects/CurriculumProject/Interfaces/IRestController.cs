using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CurriculumProject.Interfaces
{
    interface IRestController<T>
        where T : class
    {
        // GET: api/Models
        IQueryable<T> GetModels();
        // GET: api/Models/5
        IHttpActionResult GetModel(int id);
        // PUT: api/Models/5
        IHttpActionResult PutModel(int id, T model);
        // POST: api/Models
        IHttpActionResult PostModel(T model);
        // DELETE: api/Models/5
        IHttpActionResult DeleteModel(int id);
    }
}
