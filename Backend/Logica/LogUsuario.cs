using Backend.AccesoDatos;
using Backend.Modelo;
using Backend.Modelo.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogUsuario{

        public ResIngresarUsuario ingresarUsuario(ReqIngresarUsuario req) {
            ResIngresarUsuario res = new ResIngresarUsuario();

            try{
                if (req == null) {
                    res.setBadResponse(false, "Bad request!!");
                } else if (String.IsNullOrEmpty(req.usuario.nombre)) {
                    res.setBadResponse(false, "El usuario debe contener un nombre");
                } else if (String.IsNullOrEmpty(req.usuario.apellido)) {
                    res.setBadResponse(false, "El usuario debe contener un apellido");
                } else if (String.IsNullOrEmpty(req.usuario.correoElectronico)) {
                    res.setBadResponse(false, "El correo es invalido o no fue establecido");
                } else if (String.IsNullOrEmpty(req.usuario.password)) {
                    res.setBadResponse(false, "El usuario debe contener un contraseña");
                } else if (String.IsNullOrEmpty(req.usuario.numeroVerificacion)) {
                    res.setBadResponse(false, "Introduzca un numero de verificacion valido");
                } else {
                    int? idReturn = 0;
                    int? errorId = 0;
                    String errorDescripcion = "";

                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_INGRESAR_USUARIO(req.usuario.nombre, req.usuario.apellido, req.usuario.correoElectronico, req.usuario.password, req.usuario.numeroVerificacion, ref idReturn, ref errorId, ref errorDescripcion);
                    if (idReturn <= 0 || idReturn == null) {
                        res.setBadResponse(false, errorDescripcion);
                    } else {
                        res.resultado = true;
                    }
                }
            }
            catch (Exception ex) {
                res.setBadResponse(false, "Error Interno!!");
            }
            return res;
        }

        public ResActivarUsuario activarUsuario(ReqActivarUsuario req) {
            ResActivarUsuario res = new ResActivarUsuario();

            try {
                if (req == null)
                {
                    res.setBadResponse(false, "Bad Request!!");
                } else if (String.IsNullOrEmpty(req.usuario.correoElectronico)) {
                    res.setBadResponse(false, "Se requiere de un correo valido");
                } else if (String.IsNullOrEmpty(req.usuario.numeroVerificacion)) {
                    res.setBadResponse(false, "Introduzca un numero de verificacion");
                } else {
                    int? idReturn = 0;
                    int? errorId = 0;
                    String errorDescripcion = "";
                    int? filasActulizadas = 0;

                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_ACTIVAR_USUARIO(req.usuario.correoElectronico,req.usuario.numeroVerificacion,ref idReturn, ref errorId, ref errorDescripcion, ref filasActulizadas);
                    if (idReturn <= 0 || idReturn == null) {
                        res.setBadResponse(false, errorDescripcion);
                    } else { 
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex) {
                res.setBadResponse(false, "Error Interno!!");
            }
            return res;  

        }
    }
}
