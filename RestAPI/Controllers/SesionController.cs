using Backend.Logica;
using Backend.Modelo;
using Backend.Modelo.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestAPI.Controllers
{
    public class SesionController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/sesion/abrirsesion")]
        public ResAbrirSesion abrirSesion(ReqAbrirSesion req)
        {
            return new LogSesion().abrirSesion(req);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/sesion/cerrarsesion")]
        public ResCerrarSesion cerrarSesion(ReqCerrarSesion req)
        {
            return new LogSesion().cerrarSesion(req);

        }
    }
}