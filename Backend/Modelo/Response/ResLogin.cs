using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelo
{
    public class ResLogin :ResBase{
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int idUsuario { get; set; }  
        public int estado { get; set; }   
    }
}
