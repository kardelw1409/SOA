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
    public class SubjectController : RestController<Subject>
    {
        public SubjectController(IRepository<Subject> repository) : base(repository)
        {

        }

        [ResponseType(typeof(Subject))]
        public override IHttpActionResult DeleteEntity(Subject entity)
        {
            return base.DeleteEntity(entity);
        }

        public override IQueryable<Subject> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Subject))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Subject))]
        public override IHttpActionResult PostEntity(Subject entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Subject model)
        {
            return base.PutEntity(id, model);
        }
    }
}