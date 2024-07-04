using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelo

{
    public class ResBase
    {
        public Boolean resultado { get; set; }
        public string error { get; set; }

        public void setBadResponse(Boolean resultado, String error) { 
            this.resultado = resultado;
            this.error = error;

        }

    }
}
