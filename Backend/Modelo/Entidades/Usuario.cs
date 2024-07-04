using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelo
{
    public class Usuario{
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String correoElectronico { get; set; }
        public String password { get; set; }
        public String numeroVerificacion { get; set; }
        /*
        public Usuario(String correoElectronico, String numeroVerificacion) { 
            this.correoElectronico = correoElectronico;
            this.numeroVerificacion = numeroVerificacion;
        }
        public Usuario(String nombre, String Apellido, String correoElectronico, String numeroVerificacion, String password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.password = password;
            this.correoElectronico = correoElectronico;
            this.numeroVerificacion = numeroVerificacion;
        }
        */
    }
}
