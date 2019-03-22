using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CurriculumProject.Controllers
{
    public class DepartmentController : RestController<Department>
    {
        public DepartmentController(IRepository<Department> repository) : base(repository)
        {

        }
        [ResponseType(typeof(Department))]
        public override IHttpActionResult DeleteEntity(Department entity)
        {
            return base.DeleteEntity(entity);
        }


        public override IQueryable<Department> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Department))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Department))]
        public override IHttpActionResult PostEntity(Department entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Department model)
        {
            return base.PutEntity(id, model);
        }
    }
}