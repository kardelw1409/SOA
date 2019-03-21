using CurriculumProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CurriculumProject.Controllers
{
    public class RestController<T> : IRestController<T>
        where T : class, new()

    {
        protected IUnitOfWork unitOfWork;

        public IHttpActionResult DeleteModel(int id)
        {
            return null;//to do
        }

        public IHttpActionResult GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetModels()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult PostModel(T model)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult PutModel(int id, T model)
        {
            throw new NotImplementedException();
        }
    }
}