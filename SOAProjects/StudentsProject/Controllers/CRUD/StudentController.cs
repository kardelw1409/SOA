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
    public class StudentsController : CrudRestController<Student>
    {
        public StudentsController(IEntityCrudService<Student> service) : base(service)
        {

        }
        [ResponseType(typeof(Student))]
        public override IHttpActionResult DeleteEntity(Student entity)
        {
            return base.DeleteEntity(entity);
        }


        public override IQueryable<Student> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Student))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Student))]
        public override IHttpActionResult PostEntity(Student entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Student model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}