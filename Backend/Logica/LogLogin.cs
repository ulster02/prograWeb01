using Backend.AccesoDatos;
using Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogLogin
    {
        public ResLogin login(ReqLogin req) { 
             ResLogin res = new ResLogin();

            if (req == null) {
                res.setBadResponse(false, "Bad Request!");
            } else if (String.IsNullOrEmpty(req.login.correoElectronico)) {
                res.setBadResponse(false, "Correo Electronico necesario");
            } else if (String.IsNullOrEmpty(req.login.password)) {
                res.setBadResponse(false, "Contraseña es necesaria");
            } else {
                /*int? intError = 0;
                int? returnId= 0;
                String errorDescription = "";
                '*/
                int? idUsuario = 0;
                int? estado = 0;
                String nombre = "";
                String apellidos = "";
                
                conexionLinqDataContext miLinq = new conexionLinqDataContext();
                miLinq.sp_Login(req.login.correoElectronico,req.login.password, ref idUsuario, ref estado, ref nombre,ref apellidos);
                res.idUsuario = idUsuario ?? 0;
                res.estado = estado ?? 0;
                res.nombre = nombre;
                res.apellido = apellidos; 

            }
            return res;
        }
    }
}
