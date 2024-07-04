using Backend.Logica;
using Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestAPI.Controllers
{
    public class BitacoraController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/bitacora/insertarbitacora")]
        public ResInsertarBitacora insertarBitacora(ReqInsertarBitacora req)
        {
            return new LogBitacora().ingresarBitacora(req);

        }
    }
}