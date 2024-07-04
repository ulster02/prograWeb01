using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelo
{
    public class Bitacora
    {
        public String clase {  get; set; } 
        public String metodo {  get; set; } 
        public short? tipo { get; set; }
        public String descripcion { get; set; } 
        public String request {  get; set; } 
        public String response { get; set; }
    }
}
