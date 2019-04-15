using StudentsService.Context;
using StudentsService.Interfaces;
using StudentsService.Models;
using StudentsService.Repositories;
using StudentsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsService.Controllers
{
    public class GroupsController : CrudRestController<Group>
    {
        public GroupsController(IEntityCrudService<Group> service) : base(service)
        {

        }

        [ResponseType(typeof(Group))]
        public async override Task<IHttpActionResult> DeleteEntity(int id)
        {
            return await base.DeleteEntity(id);
        }

        public async override Task<IQueryable<Group>> GetEntities()
        {
            return await base.GetEntities();
        }

        [ResponseType(typeof(Group))]
        public async override Task<IHttpActionResult> GetEntity(int id)
        {
            return await base.GetEntity(id);
        }

        [ResponseType(typeof(Group))]
        public async override Task<IHttpActionResult> PostEntity(Group entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SpecialityHttpService httpService = new SpecialityHttpService("http://localhost:65357/");
            SpecialityDTO speciality = await httpService.GetProductAsync($"api/Speciality/{entity.SpecialityId}");
            if (speciality == null)
            {
                return NotFound();
            }
            await service.Create(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        [ResponseType(typeof(void))]
        public async override Task<IHttpActionResult> PutEntity(Group model)
        {
            return await base.PutEntity(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
