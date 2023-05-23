using MVC_Hospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Hospitales.Controllers
{
    public class DetailsAjaxController : Controller
    {
        ModeloHospital modelo = new ModeloHospital();

        public PartialViewResult DoctorFilter(String hospCod)
        {
            IQueryable<DOCTOR> doctores = modelo.GetDoctores(hospCod);

            if (doctores.Count() == 0)
            {
                return PartialView("_DetallesDoctores");
            }
            else
            {
                return PartialView("_DetallesDoctores", doctores);
            }
        }

        public PartialViewResult PlantillaFilter(String hospCod)
        {
            IQueryable<PLANTILLA> plantilla = modelo.GetPlantilla(hospCod);

            if (plantilla.Count() == 0)
            {
                return PartialView("_DetallesPlantilla");
            }
            else
            {
                return PartialView("_DetallesPlantilla", plantilla);
            }
        }

        public PartialViewResult SalaFilter(String hospCod)
        {
            IQueryable<SALA> sala = modelo.GetSalas(hospCod);

            if (sala.Count() == 0)
            {
                return PartialView("_DetallesSalas");
            }
            else
            {
                return PartialView("_DetallesSalas", sala);
            }
        }
    }
}