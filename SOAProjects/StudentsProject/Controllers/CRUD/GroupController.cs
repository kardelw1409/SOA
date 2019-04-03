using StudentsProject.Context;
using StudentsProject.Interfaces;
using StudentsProject.Models;
using StudentsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentsProject.Controllers
{
    public class GroupsController : CrudRestController<Group>
    {
        public GroupsController(IEntityCrudService<Group> service) : base(service)
        {

        }

        [ResponseType(typeof(Group))]
        public override IHttpActionResult DeleteEntity(Group entity)
        {
            return base.DeleteEntity(entity);
        }

        public override IQueryable<Group> GetEntities()
        {
            return base.GetEntities();
        }

        [ResponseType(typeof(Group))]
        public override IHttpActionResult GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        [ResponseType(typeof(Group))]
        public override IHttpActionResult PostEntity(Group entity)
        {
            return base.PostEntity(entity);
        }

        [ResponseType(typeof(void))]
        public override IHttpActionResult PutEntity(int id, Group model)
        {
            return base.PutEntity(id, model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
