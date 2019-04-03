using StudentsProject.Interfaces;
using StudentsProject.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsProject.Controllers
{
    public abstract class CrudRestController<TEntity> : ApiController, IRestController<TEntity>
        where TEntity : Entity
    {
        protected readonly IEntityCrudService<TEntity> service;

        public CrudRestController(IEntityCrudService<TEntity> service)
        {
            this.service = service;
        }

        public virtual IHttpActionResult GetEntity(int id)
        {
            TEntity entity = service.FindById(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        public virtual IQueryable<TEntity> GetEntities()
        {
            return service.GetAll().AsQueryable();
        }

        public virtual IHttpActionResult PostEntity(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        public virtual IHttpActionResult PutEntity(int id, TEntity model)
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
                service.Update(model);
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

        public virtual IHttpActionResult DeleteEntity(TEntity entity)
        {
            service.Remove(entity);
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
