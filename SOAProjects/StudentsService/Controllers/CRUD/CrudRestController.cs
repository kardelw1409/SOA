using StudentsService.Interfaces;
using StudentsService.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsService.Controllers
{
    public abstract class CrudRestController<TEntity> : ApiController, IRestController<TEntity>
        where TEntity : Entity
    {
        protected readonly IEntityCrudService<TEntity> service;

        public CrudRestController(IEntityCrudService<TEntity> service)
        {
            this.service = service;
        }

        public async virtual Task<IHttpActionResult> GetEntity(int id)
        {
            TEntity entity = await service.FindById(id);
            return Ok(entity);
        }

        public async virtual Task<IQueryable<TEntity>> GetEntities()
        {
            return (await service.GetAll()).AsQueryable();
        }

        public async virtual Task<IHttpActionResult> PostEntity(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Create(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        public async virtual Task<IHttpActionResult> PutEntity(TEntity model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await service.Update(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }

        public async virtual Task<IHttpActionResult> DeleteEntity(int id)
        {
            var entity = await service.Remove(id);
            return Ok(entity);
        }

        private bool EntityExists(int id)
        {
            return service.FindById(id) != null;
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }

    }
}
