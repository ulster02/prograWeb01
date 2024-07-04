using Backend.Modelo;
using Backend.Logica;
using Backend.Modelo.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestAPI.Controllers
{
    public class UsuarioController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/usuario/ingresarusuario")]
        public ResIngresarUsuario ingresarUsuario(ReqIngresarUsuario req) {
            return new LogUsuario().ingresarUsuario(req);
        
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/usuario/activarusuario")]
        public ResActivarUsuario activarUsuario(ReqActivarUsuario req) {
            return new LogUsuario().activarUsuario(req);
        }       
        
    }
}