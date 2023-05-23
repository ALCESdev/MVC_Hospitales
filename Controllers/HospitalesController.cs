using MVC_Hospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Hospitales.Controllers
{
    public class HospitalesController : Controller
    {
        ModeloHospital modelo = new ModeloHospital();

        public ActionResult VistaHospitales()
        {
            IQueryable<HOSPITAL> listaHospitales = modelo.GetHospitals();

            return View(listaHospitales);
        }

        public ActionResult VistaDetalles(String hospCod, String hospNom)
        {
            ViewBag.Nombre = hospNom;

            HOSPITAL hospital = modelo.GetHospDetails(hospCod);

            return View(hospital);
        }
    }
}