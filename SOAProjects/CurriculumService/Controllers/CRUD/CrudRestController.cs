using CurriculumService.Interfaces;
using CurriculumService.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CurriculumService.Controllers
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
            if (entity == null)
            {
                return NotFound();
            }

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

        public async virtual Task<IHttpActionResult> PutEntity(int id, TEntity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await service.Update(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public async virtual Task<IHttpActionResult> DeleteEntity(TEntity entity)
        {
            await service.Remove(entity);
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
