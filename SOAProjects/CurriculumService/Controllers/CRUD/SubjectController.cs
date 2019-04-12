using CurriculumService.Interfaces;
using CurriculumService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CurriculumService.Controllers
{
    public class SubjectController : CrudRestController<Subject>
    {
        public SubjectController(IEntityCrudService<Subject> service) : base(service)
        {

        }

        [ResponseType(typeof(Subject))]
        public override Task<IHttpActionResult> DeleteEntity(Subject entity)
        {
            return base.DeleteEntity(entity);
        }

        public override Task<IQueryable<Subject>> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Subject))]
        public override Task<IHttpActionResult> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Subject))]
        public override Task<IHttpActionResult> PostEntity(Subject entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override Task<IHttpActionResult> PutEntity(int id, Subject model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}