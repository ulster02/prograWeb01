using Backend.AccesoDatos;
using Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogBitacora
    {
        public ResInsertarBitacora ingresarBitacora(ReqInsertarBitacora req){
            ResInsertarBitacora res = new ResInsertarBitacora();

            try{
                if (req == null)
                {
                    res.setBadResponse(false, "Bad request!!");
                } else if (req.bitacora.tipo == 0) {
                    res.setBadResponse(false, "Tipo no puede ser 0");
                } else if (String.IsNullOrEmpty(req.bitacora.clase)) {
                    res.setBadResponse(false, "Clase no puede estar vacia");
                } else if (String.IsNullOrEmpty(req.bitacora.metodo)) {
                    res.setBadResponse(false, "Metodo invalido");
                } else if (String.IsNullOrEmpty(req.bitacora.descripcion)) {
                    res.setBadResponse(false, "Descripción invalida");
                } else if (String.IsNullOrEmpty(req.bitacora.request)) {
                    res.setBadResponse(false, "Invalid request");
                } else if (String.IsNullOrEmpty(req.bitacora.response)) {
                    res.setBadResponse(false, "Invalid Response");
                } else { 
                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    miLinq.SP_INSERTAR_BITACORA(req.bitacora.clase, req.bitacora.metodo, req.bitacora.tipo, req.bitacora.descripcion, req.bitacora.request, req.bitacora.response);
                    res.resultado = true;
                }
            }
            catch (Exception e) {
                res.setBadResponse(false, "Internal Error!!");
            }
            return res;
        }
    }
}
