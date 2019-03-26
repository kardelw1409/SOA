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
    public class SpecialityController : CrudRestController<Speciality>
    {
        public SpecialityController(IEntityCrudService<Speciality> service) : base(service)
        {

        }

        [ResponseType(typeof(Speciality))]
        public override IHttpActionResult DeleteEntity(Speciality entity)
        {
            return base.DeleteEntity(entity);
        }

        public override IQueryable<Speciality> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Speciality))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Speciality))]
        public override IHttpActionResult PostEntity(Speciality entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Speciality model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}