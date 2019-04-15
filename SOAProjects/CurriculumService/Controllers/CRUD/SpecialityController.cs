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
    public class SpecialityController : CrudRestController<Speciality>
    {
        public SpecialityController(IEntityCrudService<Speciality> service) : base(service)
        {

        }

        [ResponseType(typeof(Speciality))]
        public override Task<IHttpActionResult> DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override Task<IQueryable<Speciality>> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Speciality))]
        public override Task<IHttpActionResult> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Speciality))]
        public override Task<IHttpActionResult> PostEntity(Speciality entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override Task<IHttpActionResult> PutEntity(Speciality model)
        {
            return base.PutEntity(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}