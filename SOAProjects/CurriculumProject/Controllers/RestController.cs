using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CurriculumProject.Controllers
{
    public abstract class RestController<TEntity> : ApiController, IRestController<TEntity>
        where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repository;

        public RestController(IRepository<TEntity> rep)
        {
            repository = rep ?? throw new ArgumentNullException(nameof(rep));
        }

        public virtual IHttpActionResult GetEntity(int id)
        {
            TEntity entity = repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        public virtual IQueryable<TEntity> GetEntities()
        {
            return repository.GetAll().AsQueryable();
        }

        public virtual IHttpActionResult PostEntity(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Create(entity);

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
                repository.Update(model);
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
            repository.Delete(entity);
            return Ok(entity);
        }

        private bool EntityExists(int id)
        {
            return repository.Find(e => e.Id == id).Count() > 0;
        }
    }
}
