﻿using CurriculumService.Context;
using CurriculumService.Interfaces;
using CurriculumService.Models;
using CurriculumService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CurriculumService.Controllers
{
    public class FacultyController : CrudRestController<Faculty>
    {
        public FacultyController(IEntityCrudService<Faculty> service) : base(service)
        {

        }

        [ResponseType(typeof(Faculty))]
        public override Task<IHttpActionResult> DeleteEntity(Faculty entity)
        {
            return base.DeleteEntity(entity);
        }

        public override Task<IQueryable<Faculty>> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Faculty))]
        public override Task<IHttpActionResult> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Faculty))]
        public override Task<IHttpActionResult> PostEntity(Faculty entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override Task<IHttpActionResult> PutEntity(int id, Faculty model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
