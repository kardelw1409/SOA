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
    public class DepartmentController : CrudRestController<Department>
    {
        public DepartmentController(IEntityCrudService<Department> service) : base(service)
        {

        }

        [ResponseType(typeof(Department))]
        public override Task<IHttpActionResult> DeleteEntity(Department entity)
        {
            return base.DeleteEntity(entity);
        }

        public override Task<IQueryable<Department>> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Department))]
        public override Task<IHttpActionResult> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Department))]
        public override Task<IHttpActionResult> PostEntity(Department entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override Task<IHttpActionResult> PutEntity(int id, Department model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}