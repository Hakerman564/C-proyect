using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class Usuario
    {
        public string nombre { get; set; }
        public string clave { get; set; }   

        public bool operador { get; set; }

        public funciones funcion = new funciones();


    }
}
