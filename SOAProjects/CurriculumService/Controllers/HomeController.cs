﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CurriculumService.Controllers
{
    public class HomeController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello" };
        }
    }
}
