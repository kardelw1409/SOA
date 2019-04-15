using StudentsService.Interfaces;
using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsService.Controllers
{
    public class PerformancesController : CrudRestController<Performance>
    {
        public PerformancesController(IEntityCrudService<Performance> service) : base(service)
        {

        }

        [ResponseType(typeof(Performance))]
        public override Task<IHttpActionResult> DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }


        public override Task<IQueryable<Performance>> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Performance))]
        public override Task<IHttpActionResult> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Performance))]
        public override Task<IHttpActionResult> PostEntity(Performance entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override Task<IHttpActionResult> PutEntity(Performance model)
        {
            return base.PutEntity(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}