using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Modelo;
using Backend.AccesoDatos;
using Backend.Modelo.Response;

namespace Backend.Logica
{
    public class LogPublicacion{
        public ResInsertarPublicacion insertarPublicacion(ReqInsertarPublicacion req)
        {
            ResInsertarPublicacion res = new ResInsertarPublicacion();
            try
            {
                if (req == null)
                {
                    res.setBadResponse(false, "Bad Response!");
                    //res.resultado = false;
                    //res.error = "Bad Request!";
                }
                else if (req.publicacion.usuarioId == 0)
                {
                    res.setBadResponse(false, "Usuario Incorrecto!");
                    //res.resultado = false;
                    //res.error = "Usuario Incorrecto";

                }
                else if (string.IsNullOrEmpty(req.publicacion.mensaje)) {
                    res.setBadResponse(false, "Incorrecto o mensaje faltante");
                    //res.resultado = false;
                    //res.error = "Incorrecto o mensaje faltante";
                }
                else if (string.IsNullOrEmpty(req.publicacion.titulo)){
                    res.setBadResponse(false, "Titulo faltante");
                    //res.resultado = false;
                    //res.error = "Titulo faltante";
                } else if (req.publicacion.temaId == 0) {
                    res.setBadResponse(false, "Tema Incorrecto");
                    //res.resultado = false;
                    //res.error = "Tema incorrecto";
                } else {
                    int? errorId = 0;
                    int? returnId = 0;
                    String errorDescription = "";

                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_INGRESAR_PUBLICACION(req.publicacion.temaId,req.publicacion.usuarioId, req.publicacion.titulo, req.publicacion.mensaje,ref returnId, ref errorId, ref errorDescription);
                    if (returnId <= 0 || returnId == null) {
                        res.setBadResponse(false, errorDescription);
                        //res.resultado = false;
                        //res.error = errorDescription;
                    } else {
                        res.resultado = true;

                    }
                }
            } catch (Exception ex) {
                res.setBadResponse(false, "500 - ERROR INTERNO!!!");
                //res.resultado=false;
                //res.error = "500 - ERROR INTERNO!!!";
            }
            return res;
            
        }

        public ResObtenerPublicacion obtenerPublicacion(){
            ResObtenerPublicacion res = new ResObtenerPublicacion();
            
            try{
                conexionLinqDataContext miLinq = new conexionLinqDataContext();
                List<SP_OBTENER_PUBLICACIONESResult> resultSet = new List<SP_OBTENER_PUBLICACIONESResult>();
                resultSet = miLinq.SP_OBTENER_PUBLICACIONES().ToList();

                foreach (SP_OBTENER_PUBLICACIONESResult unaPublicacionLinq in resultSet) {
                    res.listaPublicaciones.Add(this.fabricPublicacion(unaPublicacionLinq));
                }
                res.resultado = true;
                
            }
            catch (Exception ex) {
                res.resultado = false;
                res.error = "500 - ERROR INTERNO!!!";
            }

            return res;
        }

        //Factoria
        private Publicacion fabricPublicacion(SP_OBTENER_PUBLICACIONESResult publicacionLinq) {
            Publicacion publicacionFabricada = new Publicacion();
            publicacionFabricada.titulo = publicacionLinq.TITULO;
            publicacionFabricada.mensaje = publicacionLinq.MENSAJE;
            publicacionFabricada.temaId = publicacionLinq.ID_TEMA;
            publicacionFabricada.usuarioId = (int?)publicacionLinq.ID_USUARIO;

            return publicacionFabricada;
        }
    }
}
