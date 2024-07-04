using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelo
{
    public class Publicacion{
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public int? temaId { get; set; }
        public int? usuarioId { get; set; }

        public Publicacion() { 
        
        }
    }
}
