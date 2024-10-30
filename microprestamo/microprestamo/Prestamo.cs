using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microprestamo
{
    internal class Prestamo
    {
        public DateTime fecha;
        public cuota cuota = new cuota();

    }

    class cuota 
    {
        public decimal monto { get; set; }
        public decimal pago { get; set; }
        public DateTime fecha1 { get; set; }
        public DateTime fecha2 { get; set; }
        public DateTime fecha3 { get; set; }
        public DateTime fecha4 { get; set; }
        public bool pago1 { get; set; }
        public bool pago2 { get; set; }
        public bool pago3 { get; set; }
        public bool pago4 { get; set; }

        public bool activo { get; set; }


        public cuota()
        {
            monto = 0;
        }
    }

}
