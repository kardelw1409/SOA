﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CurriculumProject.Controllers
{
    public class HomeController : ApiController
    {
        public IEnumerable<string> Index()
        {
            return new string[] { "Hello" };
        }
    }
}
