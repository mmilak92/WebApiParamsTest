﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiParamsTest.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}