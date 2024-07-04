using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Backend.Logica;
using Backend.Modelo;
using Backend.Modelo.Response;


namespace RestAPI.Controllers
{
    public class PublicacionController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/publicacion/ingresarpublicacion")]
        public  ResInsertarPublicacion ingresarPublicacion(ReqInsertarPublicacion req){

            return new LogPublicacion().insertarPublicacion(req);

        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/publicacion/obtenerpublicaciones")]
        public ResObtenerPublicacion obtenerPublicacion() {
            return new LogPublicacion().obtenerPublicacion();
        }

    }
}