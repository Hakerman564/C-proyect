using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class Cuenta
    {
        public string sesion { get; set; }
        public string clave { get; set; }

        public Cuenta()
        {
            this.sesion = "Desconetado";
            this.clave = "0";
        }

        public void ingresar(string sesion,string clave)
        {

        }
    }
}
