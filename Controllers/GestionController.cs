using MVC_Hospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Hospitales.Controllers
{
    public class GestionController : Controller
    {
        ModeloHospital modelo = new ModeloHospital();

        public ActionResult GestionEquipo()
        {
            return View();
        }
    }
}