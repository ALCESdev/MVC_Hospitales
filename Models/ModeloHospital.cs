using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Hospitales.Models
{
    public class ModeloHospital
    {
        ModeloHospitalDataContext contexto = new ModeloHospitalDataContext("Data Source=.;Initial Catalog=Hospital_MVC;Integrated Security=True");

        public IQueryable<HOSPITAL> GetHospitals()
        {
            var consulta = from hosp in contexto.HOSPITAL
                           select hosp;

            return consulta;
        }

        public HOSPITAL GetHospDetails(String hospCod)
        {
            var consulta = from hosp in contexto.HOSPITAL
                           where hosp.HOSPITAL_COD == hospCod
                           select hosp;

            return consulta.FirstOrDefault();
        }

        public IQueryable<DOCTOR> GetDoctores(String hospCod)
        {
            var consulta = from doc in contexto.DOCTOR
                           where doc.HOSPITAL_COD == hospCod
                           select doc;

            return consulta;
        }

        public DOCTOR GetInfoDoctor(String docNo)
        {
            var consulta = from doc in contexto.DOCTOR
                           where doc.DOCTOR_NO == docNo
                           select doc;

            return consulta.FirstOrDefault();
        }

        public IQueryable<PLANTILLA> GetPlantilla(String hopsCod)
        {
            var consulta = from plan in contexto.PLANTILLA
                           where plan.HOSPITAL_COD == hopsCod
                           select plan;

            return consulta;
        }

        public PLANTILLA GetInfoPlantilla(String empNo)
        {
            var consulta = from plan in contexto.PLANTILLA
                           where plan.EMPLEADO_NO == empNo
                           select plan;

            return consulta.FirstOrDefault();
        }

        public IQueryable<SALA> GetSalas(String hopsCod)
        {
            var consulta = from sal in contexto.SALA
                           where sal.HOSPITAL_COD == hopsCod
                           select sal;

            return consulta;
        }
    }
}