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
    public class LogSesion{

        public ResAbrirSesion abrirSesion(ReqAbrirSesion req) { 
            ResAbrirSesion res = new ResAbrirSesion();

            try {

                if (req == null) {
                    res.setBadResponse(false, "Bad Request!");
                } else if (String.IsNullOrEmpty(req.sesion.sesion)) {
                    res.setBadResponse(false, "No se contiene una sesion");
                } else if (req.sesion.usuario == 0 || req.sesion.usuario == null) {
                    res.setBadResponse(false, "Numero de usuario no valido");
                } else if (String.IsNullOrEmpty(req.sesion.origen)) {
                    res.setBadResponse(false, "Origen invalido");
                } else {
                    int? errorId = 0;
                    int? returnId = 0;
                    String errorDescription = "";

                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_ABRIR_SESION(req.sesion.sesion, req.sesion.usuario, req.sesion.origen, ref returnId, ref errorId, ref errorDescription);
                    if (returnId <= 0 || returnId == null) {
                        res.setBadResponse(false, errorDescription);
                    } else {
                        res.resultado = true;
                    }
                    
                }


            } catch (Exception ex) {
                res.setBadResponse(false, "Error Interno!!"); 
            }

            return res;
        }

        public ResCerrarSesion cerrarSesion(ReqCerrarSesion req) { 
            ResCerrarSesion res = new ResCerrarSesion();

            try{
                if (String.IsNullOrEmpty(req.sesion.sesion)){
                    res.setBadResponse(false, "Invalid Sesion");
                }else{
                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_CERRAR_SESION(req.sesion.sesion);
                    
                    res.resultado = true;
                }
            }catch (Exception ex) {
                res.setBadResponse(false, "Internal Error!!");
            }

            return res;
        }
    }
}
