﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sanatorium.Admin.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {            
            SetMyAccountViewModel();           
            return View();
        }

        
    }
}