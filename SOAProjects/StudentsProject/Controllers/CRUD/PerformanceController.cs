using StudentsProject.Interfaces;
using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsProject.Controllers
{
    public class PerformancesController : CrudRestController<Performance>
    {
        public PerformancesController(IEntityCrudService<Performance> service) : base(service)
        {

        }

        [ResponseType(typeof(Performance))]
        public override IHttpActionResult DeleteEntity(Performance entity)
        {
            return base.DeleteEntity(entity);
        }

        public override IQueryable<Performance> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Performance))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Performance))]
        public override IHttpActionResult PostEntity(Performance entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Performance model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}