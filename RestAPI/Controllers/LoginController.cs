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
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/login/login")]
        public ResLogin login(ReqLogin req) { 
            return new LogLogin().login(req);
        
        }


    }
}